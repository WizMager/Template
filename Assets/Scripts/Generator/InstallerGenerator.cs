using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ModestTree;
using UnityEditor;
using UnityEngine;

namespace Generator
{
    public class InstallerGenerator
    {
        private const string PATH = "Scripts/Game/";
        private static bool _inProgress;

        [MenuItem("Tools/Generate ControllerInstaller &g")]
        public static void GenerateManual()
        {
            if (_inProgress)
                return;

            EditorUtility.DisplayProgressBar("Installer", "Generate...", .1f);

            try
            {
                _inProgress = true;
                
                var installerTemplates = Generate();
                var directoryPath = Path.Combine(Application.dataPath, PATH);
                
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                installerTemplates.SaveToFile(directoryPath);
                
                Debug.Log($"Generated controllers: {installerTemplates.Counter}");
            }
            finally
            {
                _inProgress = false;
                
                EditorUtility.ClearProgressBar();
            }

            AssetDatabase.Refresh();
        }

        private static InstallerTemplate Generate()
        {
            var collectedTemplates = CollectTemplates();

            var generatedInstallerCode = ControllerInstallerGenerator.GenerateInstaller(InstallerTemplate.Name, collectedTemplates.Container, collectedTemplates.Namespaces);
            collectedTemplates.GeneratedInstallerCode = generatedInstallerCode;
            
            return collectedTemplates;
        }
        
        private static InstallerTemplate CollectTemplates()
        {
            var installers = new InstallerTemplate();
            
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.HasAttribute<InstallAttribute>() && !type.HasAttribute<IgnoreAttribute>());
            
            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute(typeof(InstallAttribute), false) as InstallAttribute;
              
                installers.Counter++;

                    if (!installers.Container.ContainsKey(attribute.Priority))
                        installers.Container[attribute.Priority] = new List<TypeElement>();

                    installers.Container[attribute.Priority].Add(new TypeElement(type, attribute));

                    installers.Namespaces.Add(type.Namespace);
                    installers.Namespaces.Add(attribute.Priority.GetType().Namespace);
                
            }
            return installers;
        }
    }
}