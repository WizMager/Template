using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator
{
    public static class SystemBindGenerator
    {
        private static string GetBind(TypeElement type)
        {
            return $"\t\t\tcontainer.BindInterfacesAndSelfTo<{type.Type.Name}>().AsSingle();\t// {type.Order:0000}";
        }
        
        public static IEnumerable<string> GetBinds(IEnumerable<TypeElement> types)
        {
            types = types.OrderBy(t => t.Order).ThenBy(t => t.Type.Name);

            var previous = 100000;
            foreach (var t in types)
            {
                if (Math.Abs(previous - t.Order) > 10)
                    yield return $"\n			// {t.Order:0000}";
                yield return GetBind(t);
                previous = t.Order;
            }
        }
    }
}