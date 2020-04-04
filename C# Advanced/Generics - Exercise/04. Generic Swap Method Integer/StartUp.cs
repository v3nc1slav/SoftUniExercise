namespace _04._Generic_Swap_Method_Integer
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> items = new List<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                items.Add(input);
            }
            string[] inputArgs = Console.ReadLine().Split();
            int firest = int.Parse(inputArgs[0]);
            int second = int.Parse(inputArgs[1]);
            Swaper<int> swaper = new Swaper<int>(items, firest, second);

            foreach (var item in swaper.GetList())
            {
                Console.WriteLine($"{item.GetType().FullName}: {item}");
            }
        }
    }
}
