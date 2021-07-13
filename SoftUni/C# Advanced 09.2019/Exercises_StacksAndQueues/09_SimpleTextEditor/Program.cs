using System;
using System.Collections.Generic;
using System.Text;

namespace _09_SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int countCommands = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();
            var sb = new StringBuilder();

            for (int i = 0; i < countCommands; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string result = "";
                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        if (stack.Count > 0)
                        {
                            sb.Append(stack.Peek());
                        }
                        sb.Append(input[1]);
                        stack.Push(sb.ToString().TrimEnd());
                        sb.Clear();
                        break;
                    case 2:
                        if (stack.Count == 0)
                        {
                            break;
                        }
                        int count = int.Parse(input[1]);
                        if (count <= stack.Peek().Length)
                        {
                            result = stack.Peek().Remove(stack.Peek().Length - count, count);
                        }
                        stack.Push(result);
                        break;
                    case 3:
                        if (stack.Count == 0)
                        {
                            break;
                        }
                        int index = int.Parse(input[1]) - 1;
                        if (index >= 0 && index < stack.Peek().Length)
                        {
                            char element = stack.Peek()[index];
                            Console.WriteLine(element);
                        }
                        break;
                    case 4:
                        if (stack.Count == 0)
                        {
                            break;
                        }
                        stack.Pop();
                        break;
                }
            }
        }
    }
}
