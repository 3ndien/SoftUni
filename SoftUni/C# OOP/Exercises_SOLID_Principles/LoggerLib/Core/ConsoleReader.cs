using System;

namespace LoggerLib.Core
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
