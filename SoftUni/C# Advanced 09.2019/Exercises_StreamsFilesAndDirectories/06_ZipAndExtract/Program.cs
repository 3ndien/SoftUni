using System;
using System.IO.Compression;

namespace _06_ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = @"..\..\..\res";
            string zipPath = @"..\..\..\result.zip";
            string extractPath = @"..\..\..\extract";

            ZipFile.CreateFromDirectory(startPath, zipPath);

            ZipFile.ExtractToDirectory(zipPath, extractPath);

        }
    }
}
