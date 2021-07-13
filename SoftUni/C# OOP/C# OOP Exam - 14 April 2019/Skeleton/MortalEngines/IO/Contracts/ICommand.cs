namespace MortalEngines.IO.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        string[] Data { get; }

        string Execute();
    }
}
