using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Auto_Repair_and_Service
{
    class AutoRepairaAndService

    {
        static void Main(string[] args)
        {
            PrintAutoRepairAndService();

        }

        private static void PrintAutoRepairAndService()
        {
            var queue = new Queue<string>();
            var stack = new Stack<string>();
            var cars = Console.ReadLine().Split();
            for (int i = 0; i < cars.Length; i++)
            {
                queue.Enqueue(cars[i]);
            }
            while (true)
            {
                var command = Console.ReadLine().Split('-');
                if (command[0]=="End")
                {
                    if (queue.Count>0)
                    {
                        Console.Write("Vehicles for service: ");
                        Console.Write(string.Join(", ", queue));
                        Console.WriteLine();
                    }
                    Console.Write("Served vehicles: ");
                    Console.Write(string.Join(", ", stack));
                    Console.WriteLine();
                    return;
                }
                else if (command[0]== "Service")
                {
                    if (queue.Count>0)
                    {
                        Console.WriteLine($"Vehicle {queue.Peek()} got served.");
                        stack.Push(queue.Dequeue());

                    }
                }
                else if (command[0]== "CarInfo")
                {
                    var car = command[1];
                    if (queue.Contains(car))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else if (stack.Contains(car))
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (command[0]== "History")
                {
                    Console.WriteLine(string.Join(", ",stack));
                }
            }
        }
    }
}
