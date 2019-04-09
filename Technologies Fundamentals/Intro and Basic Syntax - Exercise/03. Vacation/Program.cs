using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Vacation
{
    public class Program
    {
        public static void Main()
        {
            int peoples = int.Parse(Console.ReadLine());
            string gruops = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            if (day == "Friday")
            {
                if (gruops == "Students")
                {
                    if (peoples >= 30)
                    {
                        price = (peoples * 8.45) * 0.85;
                    }
                    else
                    {
                        price = peoples * 8.45;

                    }
                }
                else if (gruops == "Business")
                {
                    if (peoples > +100)
                    {
                        price = (peoples - 10) * 10.90;
                    }
                    else
                    {
                        price = peoples * 10.90;

                    }
                }
                else if (gruops == "Regular")
                {
                    if (peoples <= 20 && peoples >= 10)
                    {
                        price = (peoples * 15) * 0.95;
                    }
                    else
                    {
                        price = peoples * 15;

                    }
                }
            }
            else if (day == "Saturday")
            {
                if (gruops == "Students")
                {
                    if (peoples >= 30)
                    {
                        price = (peoples * 9.80) * 0.85;
                    }
                    else
                    {
                        price = peoples * 9.80;

                    }
                }
                else if (gruops == "Business")
                {
                    if (peoples > +100)
                    {
                        price = (peoples - 10) * 15.60;
                    }
                    else
                    {
                        price = peoples * 15.60;

                    }
                }
                else if (gruops == "Regular")
                {
                    if (peoples <= 20 && peoples >= 10)
                    {
                        price = (peoples * 20) * 0.95;
                    }
                    else
                    {
                        price = peoples * 20;

                    }
                }
            }
            else if (day == "Sunday")
            {
                if (gruops == "Students")
                {
                    if (peoples >= 30)
                    {
                        price = (peoples * 10.46) * 0.85;
                    }
                    else
                    {
                        price = peoples * 10.46;

                    }
                }
                else if (gruops == "Business")
                {
                    if (peoples > +100)
                    {
                        price = (peoples - 10) * 16;
                    }
                    else
                    {
                        price = peoples * 16;

                    }
                }
                else if (gruops == "Regular")
                {
                    if (peoples <= 20 && peoples >= 10)
                    {
                        price = (peoples * 22.50) * 0.95;
                    }
                    else
                    {
                        price = peoples * 22.50;

                    }
                }
            }
            Console.WriteLine($"Total price: {price:f2}");
        }

    }
}