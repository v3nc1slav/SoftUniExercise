using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fashion_Boutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            PrintFashionBoutique();
        }

        private static void PrintFashionBoutique()
        {
            var stack = new Stack<int>();
            var counter = 1;
            var clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < clothes.Length; i++)
            {
                stack.Push(clothes[i]);
            }
            var capacityRack = int.Parse(Console.ReadLine());
            var rack = capacityRack;
            while (stack.Count>0)
            {
                if (stack.Peek() <= rack)
                {
                    rack -= stack.Pop();
                }
                else
                {
                    counter++;
                    rack = capacityRack;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
