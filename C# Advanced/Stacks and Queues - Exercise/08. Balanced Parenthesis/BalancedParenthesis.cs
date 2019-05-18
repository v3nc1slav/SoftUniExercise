using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Balanced_Parenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            PrintBalancedParenthesis();
        }

        private static void PrintBalancedParenthesis()
        {
            var parentheses = new Stack<char>();
            var input = Console.ReadLine().Trim();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '('
               || input[i] == '{'
               || input[i] == '[')
                {
                    parentheses.Push(input[i]);
                    continue;
                }
                if (parentheses.Count==0 && (input[i] == ')'
               || input[i] == '}'
               || input[i] == ']'))
                {
                    Console.WriteLine("NO");
                    return;
                }
                if (input[i] == ')' && parentheses.Peek() == '(')
                {
                    parentheses.Pop();
                }
                else if (input[i] == '}' && parentheses.Peek() == '{')
                {
                    parentheses.Pop();
                }
                else if (input[i] == ']' && parentheses.Peek() == '[')
                {
                    parentheses.Pop();
                }
            }
            if (parentheses.Count > 0)
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
