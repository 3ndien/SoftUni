using LoggerLib.Appenders;
using LoggerLib.Layouts;

namespace LoggerLib.Core.Factories
{
    public interface IAppenderFactory
    {
        IAppender Create(string data, ILayout layout);
    }
}
