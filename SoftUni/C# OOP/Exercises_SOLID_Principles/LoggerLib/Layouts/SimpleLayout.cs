namespace LoggerLib.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";

        public string Type => this.GetType().Name;
    }
}
