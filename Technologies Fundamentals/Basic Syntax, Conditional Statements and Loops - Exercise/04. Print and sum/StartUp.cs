namespace _04._Print_and_sum
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            int Frist = int.Parse(Console.ReadLine());
            int Second = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = Frist; i <= Second; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
