using LoggerLib.Loggers;

namespace LoggerLib.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public void InterpretCommand(Logger logger, string[] data)
        {
            string command = data[0];
            string dateTime = data[1];
            string message = data[2];

            switch (command)
            {
                case "INFO":
                    logger.Info(dateTime, message);
                    break;
                case "WARNING":
                    logger.Warning(dateTime, message);
                    break;
                case "ERROR":
                    logger.Warning(dateTime, message);
                    break;
                case "CRITICAL":
                    logger.Critical(dateTime, message);
                    break;
                case "FATAL":
                    logger.Fatal(dateTime, message);
                    break;
            }
        }
    }
}
