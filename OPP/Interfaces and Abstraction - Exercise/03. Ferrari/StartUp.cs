using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            IFerrari ferrari = new Ferrari(name);
            Console.WriteLine($"{ferrari.Model}/{ferrari.Brakes()}/{ferrari.Gas()}/{ferrari.NameDriver}");

        }
    }
}
