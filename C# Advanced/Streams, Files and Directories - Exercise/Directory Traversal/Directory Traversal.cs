using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Directory_Traversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(".", "*.*");
            var dictinary = new Dictionary<string, Dictionary<string, double>>();
            var info = new DirectoryInfo(".");
            var finalFiles = info.GetFiles();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ @"/report.txt";
            foreach (var item in finalFiles)
            {
                var size = item.Length / 1024d;
                var fullName = item.Name;
                var extension = item.Extension;

                if (!dictinary.ContainsKey(extension))
                {
                    dictinary.Add(extension, new Dictionary<string, double>());
                }
                if (!dictinary[extension].ContainsKey(fullName))
                {
                    dictinary[extension].Add(fullName, size);
                }
                var finalDictanary = dictinary
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);

                foreach (var kvp in finalDictanary)
                {
                    File.AppendAllText(path, kvp.Key
                        +$"{Environment.NewLine}");
                    foreach (var sss in kvp.Value.OrderBy(x => x.Value))
                    {
                        File.AppendAllText(path, $"--{sss.Key} - {sss.Value:f3}kb"
                            + $"{Environment.NewLine}");
                    }
                }

            }
        }
    }
}
