using System.Linq;
using System.Text;

namespace LoggerLib.Loggers
{
    public class LogFIle
    {
        private StringBuilder stringBuilder;

        public LogFIle()
        {
            this.stringBuilder = new StringBuilder();
        }

        public int FileSize { get; private set; }

        public void Write(string message)
        {
            this.stringBuilder.AppendLine(message);
            this.FileSize += message.Where(c => char.IsLetter(c)).Sum(c => c);
        }
    }
}
