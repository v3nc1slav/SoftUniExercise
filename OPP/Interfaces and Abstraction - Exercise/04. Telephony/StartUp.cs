using System;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phonesNumber = Console.ReadLine().Split().ToArray();
            string[] web = Console.ReadLine().Split().ToArray();
            Smartphone smartphone = new Smartphone();

            foreach (var number in phonesNumber)
            {
                try
                {
                    Console.WriteLine(smartphone.CallingPhones(number));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var kvp in web)
            {
                try
                {
                    Console.WriteLine(smartphone.Browsing(kvp));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
