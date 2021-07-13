using System;
using System.Linq;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack<int>();

            var cmdArgs = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            while (cmdArgs[0] != "END")
            {
                switch (cmdArgs[0])
                {
                    case "Push":
                        var elements = cmdArgs.Skip(1).Select(int.Parse);
                        stack.Push(elements);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }

                        break;
                    default:
                        break;
                }

                cmdArgs = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            PrintStack(stack);
            PrintStack(stack);
        }

        private static void PrintStack(CustomStack<int> stack)
        {
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
