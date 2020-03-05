using System;


namespace _11.Multiplication_Table_2._0
{
    public class StartUp
    {
        public static void Main()
        {
            int theInteger = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());
            if (times > 10)
            {
                Console.WriteLine($"{theInteger} X {times} = {theInteger * times}");
            }
            for (int i = times; i <= 10; i++)
            {
                Console.WriteLine($"{theInteger} X {times} = {theInteger * times}");
                times++;
            }
        }
    }
}
