using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string result;

            while (true)
            {
                try
                {
                    result = this.commandInterpreter.Read(Console.ReadLine());

                    if (result == null)
                    {
                        break;
                    }
                    Console.WriteLine(result);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
