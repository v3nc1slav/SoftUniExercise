using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Queue_Operations 
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            PrintBasicQueueOperations();
        }

        private static void PrintBasicQueueOperations()
        {
            var NSX = Console.ReadLine().Split();
            var command = Console.ReadLine().Split();
            var stack = new Queue<string>();
            for (int i = 0; i < int.Parse(NSX[0]); i++)
            {
                stack.Enqueue(command[i]);
            }
            for (int i = 0; i < int.Parse(NSX[1]); i++)
            {
                stack.Dequeue();
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
