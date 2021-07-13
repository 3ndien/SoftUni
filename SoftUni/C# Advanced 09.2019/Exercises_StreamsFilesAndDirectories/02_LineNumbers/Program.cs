using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz ".ToCharArray();
            char[] punctuationSymbols = { '-', ',', '.', '!', '?', ' ', '\'' };
            int wordsCount = 0;
            int punctSignsCount = 0;
            var sb = new StringBuilder();
            string[] lines = File.ReadAllLines("text.txt");
            for (int l = 0; l < lines.Length; l++)
            {
                wordsCount = lines[l].Split(punctuationSymbols, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Length).Sum();
                punctSignsCount = lines[l].Split(alphabet, StringSplitOptions.RemoveEmptyEntries).ToArray().Length;
                sb.Append($"Line {l+1}: ");
                sb.Append($"{lines[l]}");
                sb.Append($" ({wordsCount})({punctSignsCount})");
                sb.AppendLine();

                lines[l] = sb.ToString().TrimEnd();
                sb.Clear();
                wordsCount = 0;
                punctSignsCount = 0;
            }
            File.WriteAllLines("../../../output.txt", lines);
        }
    }
}
