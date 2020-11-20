namespace Recursive_Drawing
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            Print(input);
        }

        private static void Print(int input)
        {
            if (input==0)
            {
                return;
            }
            Console.WriteLine(new string ('*', input));

            Print(input - 1);

            Console.WriteLine(new string('#', input));
        }
    }
}
