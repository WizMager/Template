﻿using System;
using System.Collections.Generic;
using System.Linq;
using Game.Bootstrap;

namespace Generator
{
    public class ControllerInstallerGenerator
    {
        public static string GetInstaller(
            string name,
            string ns,
            string methods,
            string body
        )
        {
            return $@"{ns}
using Zenject;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by InstallerGenerator based on Entitas.InstallerGenerator2 by SmokyOoOwizard.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Game
{{
	public class {name} : MonoInstaller
    {{
		public override void InstallBindings()
        {{
            var container = Container;
{methods}
            Container.BindInterfacesAndSelfTo<Bootstrap.{nameof(Bootstrap)}>().AsSingle().NonLazy();
		}}

{body}	
    }}
}}";
        }

        public static string GetMethodCall(string name)
        {
            return $"\t\t\t{name}(container);";
        }

        public static string GetMethodBody(string name, string body)
        {
            return $"\t\tprivate void {name}(DiContainer container)\n\t\t{{{body}\t\t}}";
        }

        public static string GenerateInstaller(string name, Dictionary<Enum, List<TypeElement>> container, List<string> nameSpaces)
        {
            var nameSpacesSorted = nameSpaces
                .Distinct()
                .Where(nameSpace => !string.IsNullOrWhiteSpace(nameSpace) && nameSpace != "Generator")
                .OrderBy(nameSpace => nameSpace);

            var builtNameSpaces = string.Join("\n", nameSpacesSorted.Select(s => "using " + s + ";"));

            var notEmptyTypes = container.Select(kvp => new
                {
                    methodName = kvp.Key.ToString(),
                    types = kvp.Value,
                    binds = ControllerBindGenerator.GetBinds(kvp.Value)
                })
                .Where(s => s.binds.Any())
                .ToList();

            var calls = notEmptyTypes.Select(s => GetMethodCall(s.methodName));
            var builtCalls = string.Join("\n", calls);
            
            var body = notEmptyTypes.Select(s => GetMethodBody(s.methodName, string.Join("\n", s.binds) + "\n"));
            var builtBody = string.Join("\n\n", body);

            return GetInstaller(name, builtNameSpaces, builtCalls, builtBody);
        }
    }
}