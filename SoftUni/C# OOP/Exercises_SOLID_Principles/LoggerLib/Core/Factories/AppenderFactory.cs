using LoggerLib.Appenders;
using LoggerLib.Layouts;
using System;
using System.Linq;
using System.Reflection;

namespace LoggerLib.Core.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender Create (string data, ILayout layout)
        {
            string[] appenderData = data.Split();
            string appenderType = appenderData[0];

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == appenderType);

            if (type == null)
            {
                throw new ArgumentException("Invalid Appender Type!");
            }

            IAppender appender = (IAppender)Activator.CreateInstance(type, layout);

            if (appenderData.Length == 3)
            {
                appender.ReportLevel = Enum.Parse<ReportLevel>(appenderData[2], true);
            }

            return appender;
        }
    }
}