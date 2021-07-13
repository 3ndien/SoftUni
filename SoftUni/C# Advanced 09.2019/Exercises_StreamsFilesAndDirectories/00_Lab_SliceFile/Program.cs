using System;
using System.IO;

namespace _00_Lab_SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new byte[1864];
            var leftToWrite = new byte[0];
            long totalSize = new FileInfo("sliceMe.txt").Length;
            long partSize = (long)Math.Ceiling(totalSize / 5.0);

            using(var reader = new FileStream("sliceMe.txt", FileMode.Open, FileAccess.Read))
            {
                for (int i = 0; i < 5; i++)
                {
                    using (var writer = new FileStream($"sliceMe-{i}.txt", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        writer.Write(leftToWrite, 0, leftToWrite.Length);

                        long totalRead = leftToWrite.Length;
                        
                        while (true)
                        {
                            int readed = reader.Read(buffer, 0, buffer.Length);
                            totalRead += readed;
                            
                            if (readed == 0)
                            {
                                break;
                            }
                            
                            if (totalRead > partSize)
                            {
                                leftToWrite = new byte[readed];
                                leftToWrite = buffer;
                                break;
                            }

                            writer.Write(buffer, 0, readed);
                        }
                    }
                
                }
            }

        }
    }
}
