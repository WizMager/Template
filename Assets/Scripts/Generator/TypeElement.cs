using System;

namespace Generator
{
    public class TypeElement
    {
        public readonly Type Type;
        public readonly EExecutionPriority Priority;
        public readonly int Order;

        public TypeElement(Type type, InstallAttribute attribute)
        {
            Type = type;
            Priority = attribute.Priority;
            Order = attribute.Order;
        }
    }
}