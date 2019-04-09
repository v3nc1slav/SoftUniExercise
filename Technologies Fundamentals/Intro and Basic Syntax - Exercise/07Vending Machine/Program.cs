using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Vending_Machine
{
    public class Program
    {
        public static void Main()
        {
            double startSum = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Start")
                {
                    while (true)
                    {
                        string product = Console.ReadLine();
                        if (product == "Nuts")
                        {
                            if (startSum >= 2.0)
                            {
                                Console.WriteLine("Purchased nuts");
                                startSum -= 2.0;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                        }
                        else if (product == "Water")
                        {
                            if (startSum >= 0.7)
                            {
                                Console.WriteLine("Purchased water");
                                startSum -= 0.7;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                        }
                        else if (product == "Crisps")
                        {
                            if (startSum >= 1.50)
                            {
                                Console.WriteLine("Purchased crisps");
                                startSum -= 1.50;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                        }
                        else if (product == "Soda")
                        {
                            if (startSum >= 0.80)
                            {
                                Console.WriteLine("Purchased soda");
                                startSum -= 0.80;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                        }
                        else if (product == "Coke")
                        {
                            if (startSum >= 1.00)
                            {
                                Console.WriteLine("Purchased coke");
                                startSum -= 1.00;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                        }
                        else if (product == "End")
                        {
                            Console.WriteLine($"Change: {startSum:f2}");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid product");
                        }
                    }

                }
                double money = double.Parse(input);
                if (money == 0.1 || money == 0.20 || money == 0.5 || money == 1 || money == 2)
                {
                    startSum += money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }
            }
        }
    }
}