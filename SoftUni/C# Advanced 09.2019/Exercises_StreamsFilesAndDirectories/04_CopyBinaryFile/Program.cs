using System;
using System.IO;

namespace _04_CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new byte[2048];
            using (var reader = new FileStream("../../../copyMe.png", FileMode.Open, FileAccess.Read))
            {
                using (var writer = new FileStream("../../../result.png", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    while (true)
                    {
                        int readed = reader.Read(buffer, 0, buffer.Length);

                        if (readed == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, readed);
                    }
                }
            }
        }
    }
}
