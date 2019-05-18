using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Basic_Stack_Operations
{
    class BasicStackOperations 
    {
        static void Main(string[] args)
        {
            PrintBasicStackOperations();
        }

        private static void PrintBasicStackOperations()
        {
            var NSX = Console.ReadLine().Split();
            var command = Console.ReadLine().Split();
            var stack = new Stack<string>();
            for (int i = 0; i < int.Parse(NSX[0]); i++)
            {
                stack.Push(command[i]);
            }
            for (int i = 0; i < int.Parse(NSX[1]); i++)
            {
                stack.Pop();
            }
            var exist = stack.Contains(NSX[2].ToString());
            if (exist == true)
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {

                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
