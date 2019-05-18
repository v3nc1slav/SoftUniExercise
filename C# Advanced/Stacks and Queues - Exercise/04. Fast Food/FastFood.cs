using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fast_Food
{
    class FastFood
    {
        static void Main(string[] args)
        {
            PrintFastFood();
        }

        private static void PrintFastFood()
        {
            var QuantityOfTheFood = int.Parse(Console.ReadLine());
            var stackOrders = new Queue<int>();
            var command = Console.ReadLine().Split().Select(int.Parse);
            foreach (var item in command)
            {
                stackOrders.Enqueue(item);
            }
            Console.WriteLine(stackOrders.Max());
            while (stackOrders.Count > 0)
            {
                if (stackOrders.Peek() <= (QuantityOfTheFood))
                {
                    QuantityOfTheFood = QuantityOfTheFood - stackOrders.Dequeue();
                }
                else
                {
                    Console.Write($"Orders left: ");
                    Console.Write(string.Join(" ", stackOrders));
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
