using LoggerLib.Appenders;
using LoggerLib.Core.Factories;
using LoggerLib.Layouts;
using LoggerLib.Loggers;
using System;
using System.Linq;

namespace LoggerLib.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private ILayoutFactory layoutFactory;
        private IAppenderFactory appenderFactory;
        private ICommandInterpreter commandInterpreter;
        private readonly ILoggerReport loggerReport;

        public Engine(IReader reader, 
                      ILayoutFactory layoutFactory, 
                      IAppenderFactory appenderFactory, 
                      ICommandInterpreter commandInterpreter, 
                      ILoggerReport loggerReport)
        {
            this.reader = reader;
            this.layoutFactory = layoutFactory;
            this.appenderFactory = appenderFactory;
            this.commandInterpreter = commandInterpreter;
            this.loggerReport = loggerReport;
        }

        public void Run()
        {
            int appendersCount = int.Parse(reader.Read());
            IAppender[] appenders = new IAppender[appendersCount];

            for (int i = 0; i < appendersCount; i++)
            {
                string data = this.reader.Read();

                ILayout layout = layoutFactory.Create(data);
                IAppender appender = appenderFactory.Create(data, layout);
                appenders[i] = appender;
            }

            string input;
            Logger logger = new Logger(appenders);

            while ((input = this.reader.Read()) != "END")
            {
                string[] data = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                this.commandInterpreter.InterpretCommand(logger, data);
            }
            
            this.loggerReport.Report(logger);

        }
    }
}
