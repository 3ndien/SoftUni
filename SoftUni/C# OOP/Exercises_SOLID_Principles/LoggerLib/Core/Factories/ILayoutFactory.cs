using LoggerLib.Layouts;

namespace LoggerLib.Core.Factories
{
    public interface ILayoutFactory
    {
        ILayout Create(string data);
    }
}
