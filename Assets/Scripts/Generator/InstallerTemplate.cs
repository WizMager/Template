using System;
using System.Collections.Generic;
using System.IO;

namespace Generator
{
    public class InstallerTemplate
    {
        public readonly Dictionary<Enum, List<TypeElement>> Container = new();
        public readonly List<string> Namespaces = new();
        
        public string GeneratedInstallerCode;
        public int Counter;
        public static string Name => "SystemsInstaller";

        public void SaveToFile(string path)
        {
            var filepath = Path.Combine(path, Name) + ".cs";
            
            if (File.Exists(filepath))
                File.Delete(filepath);
            
            File.WriteAllText(filepath, GeneratedInstallerCode);
        }
    }
}