
using _07_InfernoInfinity.Core.Contracts;
using _07_InfernoInfinity.Core.Data.Contracts;

namespace _07_InfernoInfinity.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.data = data;
        }

        public virtual string[] Data { get => this.data; }

        public abstract void Execute();
    }
}
