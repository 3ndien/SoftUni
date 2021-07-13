using LoggerLib.Layouts;
using System;
using System.Linq;
using System.Reflection;

namespace LoggerLib.Core.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout Create(string data)
        {
            string[] layoutData = data.Split();
            string layoutType = layoutData[1];

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == layoutType);

            if (type == null)
            {
                throw new ArgumentException("Invalid Layout Type");
            }

            ILayout layout = (ILayout)Activator.CreateInstance(type);

            return layout;
        }
    }
}
