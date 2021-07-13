using System;

namespace _07_InfernoInfinity.Core.Commands
{
    public class EndCommand : Command
    {
        public EndCommand(string[] data) 
            : base(data)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
