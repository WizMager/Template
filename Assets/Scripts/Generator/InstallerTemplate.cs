using System;
using System.Collections.Generic;
using System.IO;

namespace Generator
{
    public class InstallerTemplate
    {
        public readonly Dictionary<Enum, List<TypeElement>> Container = new()
        {
            { EExecutionPriority.Urgent, new List<TypeElement>() },
            { EExecutionPriority.High, new List<TypeElement>() },
            { EExecutionPriority.Normal, new List<TypeElement>() },
            { EExecutionPriority.Low, new List<TypeElement>() },
        };
        
        public readonly List<string> Namespaces = new();
        
        public string GeneratedInstallerCode;
        public int Counter;
        public static string Name => "ControllersInstaller";

        public void SaveToFile(string path)
        {
            var filepath = Path.Combine(path, Name) + ".cs";
            
            if (File.Exists(filepath))
                File.Delete(filepath);
            
            File.WriteAllText(filepath, GeneratedInstallerCode);
        }
    }
}