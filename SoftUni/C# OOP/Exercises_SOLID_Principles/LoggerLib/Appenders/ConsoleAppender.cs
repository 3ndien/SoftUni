using LoggerLib.Core;
using LoggerLib.Layouts;
using LoggerLib.Loggers;
using System;
using System.Text;

namespace LoggerLib.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout, new LogFIle())
        {
            this.AllMessages = new StringBuilder();
        }

        public StringBuilder AllMessages { get; private set; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                this.AllMessages.AppendLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
                this.MessagesCount++;
            }
        }
    }
}
