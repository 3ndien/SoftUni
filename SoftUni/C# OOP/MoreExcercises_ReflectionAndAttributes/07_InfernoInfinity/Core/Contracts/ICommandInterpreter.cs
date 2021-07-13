namespace _07_InfernoInfinity.Core.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string commandName, string[] data);
    }
}
