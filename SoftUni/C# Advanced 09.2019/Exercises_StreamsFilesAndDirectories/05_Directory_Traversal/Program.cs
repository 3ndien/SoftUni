using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
            var files = directoryInfo.GetFiles();
            var dict = new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in files)
            {
                string name = file.Name;
                string extention = file.Extension;
                long size = file.Length;

                if (!dict.ContainsKey(extention))
                {
                    dict.Add(extention, new Dictionary<string, long>());
                }
                if (!dict[extention].ContainsKey(name))
                {
                    dict[extention].Add(name, size);
                }
            }

            var orderedFiles = dict
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key).ToDictionary(k => k.Key, v => v.Value
                                                .OrderBy(s => s.Value)
                                                .ToDictionary(sk => sk.Key, sv => sv.Value));

            using (var writer = new StreamWriter("report.txt"))
            {
                foreach (var ext in orderedFiles)
                {
                    writer.WriteLine($"{ext.Key}");

                    foreach (var f in ext.Value)
                    {
                        writer.WriteLine($"--{f.Key} - {f.Value / 1000.0:f3}");
                    }
                }
            }
        }
    }
}
