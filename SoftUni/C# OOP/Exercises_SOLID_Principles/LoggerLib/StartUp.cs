using LoggerLib.Core;
using LoggerLib.Core.Factories;

namespace LoggerLib
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            ILayoutFactory layoutFactory = new LayoutFactory();
            IAppenderFactory appenderFactory = new AppenderFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            ILoggerReport loggerReport = new LoggerReport();

            var engine = new Engine(reader, layoutFactory, appenderFactory, commandInterpreter, loggerReport);
            engine.Run();
        }
    }
}
