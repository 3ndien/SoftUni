using _07_InfernoInfinity.Core.Contracts;
using System;
using System.Linq;

namespace _07_InfernoInfinity.Core
{
    public class Engine : IRunable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }


        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split(';');
                    string commandName = data[0];
                    string[] commandData = data.Skip(1).ToArray();
                    IExecutable result = commandInterpreter.InterpretCommand(commandName, commandData);
                    result.Execute();
                }
                catch (Exception e)
                {
                    //throw new Exception(e.Message);
                }
            }
            
        }
    }
}
