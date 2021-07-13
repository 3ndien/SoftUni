using LoggerLib.Layouts;
using LoggerLib.Loggers;

namespace LoggerLib.Appenders
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout, LogFIle logFIle)
        {
            this.Layout = layout;
            this.LogFIle = logFIle;
            this.ReportLevel = ReportLevel.Info;
        }

        public ReportLevel ReportLevel { get; set; }
        
        public ILayout Layout { get; }
        
        public LogFIle LogFIle { get; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.Type}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}";
        }
    }
}
