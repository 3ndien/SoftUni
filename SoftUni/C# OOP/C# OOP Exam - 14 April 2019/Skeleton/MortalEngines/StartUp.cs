namespace MortalEngines
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IMachinesManager machinesManager = new MachinesManager();
            IReader reader = new Reader(machinesManager);
            IWriter writer = new Writer();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}