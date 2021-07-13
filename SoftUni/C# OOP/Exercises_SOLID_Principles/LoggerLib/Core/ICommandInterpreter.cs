using LoggerLib.Loggers;

namespace LoggerLib.Core
{
    public interface ICommandInterpreter
    {
        void InterpretCommand(Logger logger, string[] data);
    }
}
