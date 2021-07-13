using LoggerLib.Core;
using LoggerLib.Layouts;
using LoggerLib.Loggers;
using System;
using System.IO;

namespace LoggerLib.Appenders
{
    public class FileAppender : Appender
    {
        private const string Path = "../../../Logs File.txt";

        public FileAppender(ILayout layout) 
            : base(layout, new LogFIle())
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                File.AppendAllText(Path, string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine);
                this.LogFIle.Write(string.Format(this.Layout.Format, dateTime, reportLevel, message));
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.LogFIle.FileSize}";
        }
    }
}
