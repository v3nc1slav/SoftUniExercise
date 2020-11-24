namespace RecursiveFactorial
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        private static int Factorial(int n)
        {
            if (n == 1) return 1;
            return n * Factorial(n - 1);
        }
    }
}
