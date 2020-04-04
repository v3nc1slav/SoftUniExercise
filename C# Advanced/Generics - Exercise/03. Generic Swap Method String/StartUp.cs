namespace _03._Generic_Swap_Method_String
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> items = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                items.Add(input);
            }
            string[] inputArgs = Console.ReadLine().Split();
            int firest = int.Parse(inputArgs[0]);
            int second = int.Parse(inputArgs[1]);
            Swaper<string> swaper = new Swaper<string>(items, firest, second);

            foreach (var item in swaper.GetList())
            {
                Console.WriteLine($"{item.GetType().FullName}: {item}");
            }
        }
    }
}
