using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            string opening = "{([";
            string closing = "})]";
            var stack = new Stack<int>();
            int index = -1;
            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (opening.Any(p => p == input[i]))
                {
                    index = opening.IndexOf(input[i]);
                    stack.Push(index);
                }
                else
                {
                    index = closing.IndexOf(input[i]);
                    if (stack.Count == 0 || stack.Peek() != index)
                    {
                        isBalanced = false;
                        break;
                    }

                    stack.Pop();
                }
            }

            if (stack.Count != 0 || !isBalanced)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }         
    }
}
