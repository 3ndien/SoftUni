namespace LoggerLib.Layouts
{
    public interface ILayout
    {
        string Format { get; }

        string Type { get; }
    }
}
