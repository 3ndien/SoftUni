using LoggerLib.Appenders;
using LoggerLib.Loggers;
using System;
using System.Linq;

namespace LoggerLib.Core
{
    public class LoggerReport : ILoggerReport
    {
        public void Report(Logger logger)
        {
            IAppender consoleAppender = logger.Apenders.FirstOrDefault(a => a.GetType().Name == "ConsoleAppender");

            Console.WriteLine(((ConsoleAppender)consoleAppender).AllMessages);
            Console.WriteLine("Logger info" + Environment.NewLine);

            foreach (Appender appender in logger.Apenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
