namespace _07._Theatre_Promotion
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            string Day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            if (age < 0)
            {
                Console.WriteLine("Error!");
            }
            else if (Day == "Weekday")
            {
                if (age <= 18)
                {
                    Console.WriteLine("12$");
                }
                else if (age <= 64)
                {
                    Console.WriteLine("18$");
                }
                else
                {
                    Console.WriteLine("12$");
                }
            }
            else if (Day == "Weekend")
            {
                if (age <= 18)
                {
                    Console.WriteLine("15$");
                }
                else if (age <= 64)
                {
                    Console.WriteLine("20$");
                }
                else
                {
                    Console.WriteLine("15$");
                }
            }
            else if (Day == "Holiday")
            {
                if (age <= 18)
                {
                    Console.WriteLine("5$");
                }
                else if (age <= 64)
                {
                    Console.WriteLine("12$");
                }
                else
                {
                    Console.WriteLine("10$");
                }
            }
    }
}
