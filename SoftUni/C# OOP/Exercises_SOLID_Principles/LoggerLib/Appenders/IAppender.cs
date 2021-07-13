using LoggerLib.Core;

namespace LoggerLib.Appenders
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
