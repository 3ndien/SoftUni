using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IManagerController managerController;

        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        public void Run()
        {
            string[] inputArgs;
            var result = string.Empty;
            while (true)
            {
                inputArgs = this.reader.ReadLine().Split();
                string commandName = inputArgs[0];

                if (commandName == "Exit")
                {
                    break;
                }

                try
                {
                    switch (commandName)
                    {
                        case "AddPlayer":
                            result = this.managerController.AddPlayer(inputArgs[1], inputArgs[2]);
                            break;
                        case "AddCard":
                            result = this.managerController.AddCard(inputArgs[1], inputArgs[2]);
                            break;
                        case "AddPlayerCard":
                            result = this.managerController.AddPlayerCard(inputArgs[1], inputArgs[2]);
                            break;
                        case "Fight":
                            result = this.managerController.Fight(inputArgs[1], inputArgs[2]);
                            break;
                        case "Report":
                            result = this.managerController.Report();
                            break;
                    }
                    
                }
                catch (ArgumentException ae)
                {
                    result = ae.Message;
                }
                catch (TargetInvocationException tie)
                {
                    result = tie.InnerException.Message;
                }
                
                this.writer.WriteLine(result);

            }
            
        }
    }
}
