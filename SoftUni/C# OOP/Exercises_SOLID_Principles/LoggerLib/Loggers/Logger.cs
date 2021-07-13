using System;
using LoggerLib.Appenders;

namespace LoggerLib.Loggers
{
    public class Logger
    {
        public Logger(params IAppender[] apenders)
        {
            this.Apenders = apenders;
        }

        public IAppender[] Apenders { get; }

        public void Info(string dataTime, string message)
        {
            foreach (IAppender apender in this.Apenders)
            {
                apender.Append(dataTime, ReportLevel.Info, message);
            }
        }

        public void Error(string dataTime, string message)
        {
            foreach (IAppender apender in this.Apenders)
            {
                apender.Append(dataTime, ReportLevel.Error, message);
            }

        }

        public void Warning(string dataTime, string message)
        {
            foreach (IAppender apender in this.Apenders)
            {
                apender.Append(dataTime, ReportLevel.Warning, message);
            }

        }

        public void Fatal(string dataTime, string message)
        {
            foreach (IAppender apender in this.Apenders)
            {
                apender.Append(dataTime, ReportLevel.Fatal, message);
            }
        }

        public void Critical(string dataTime, string message)
        {
            foreach (IAppender apender in this.Apenders)
            {
                apender.Append(dataTime, ReportLevel.Critical, message);
            }
        }
    }
}
