namespace _06._Strong_number
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int finalSum = 0;
            for (int i = 0; i < number.ToString().Length; i++)
            {
                char a = number.ToString()[i];
                string input = a.ToString();
                int oneNamber = int.Parse(input);
                int sum = 1;
                for (int j = 1; j <= oneNamber; j++)
                {
                    sum *= j;
                }
                finalSum += sum;
            }
            if (finalSum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
