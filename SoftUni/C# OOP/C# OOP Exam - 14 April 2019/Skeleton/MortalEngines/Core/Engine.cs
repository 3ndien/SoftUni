namespace MortalEngines.Core
{
    using Contracts;
    using IO.Contracts;

    using System;

    public class Engine : IEngine
    {
        private IReader reader;

        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var commands = reader.ReadCommands();

            foreach (ICommand command in commands)
            {
                try
                {
                    string result = command.Execute();
                    this.writer.Write(result);
                }
                catch (Exception e)
                {
                    this.writer.Write(e.Message);
                }
            }
        }
    }
}
