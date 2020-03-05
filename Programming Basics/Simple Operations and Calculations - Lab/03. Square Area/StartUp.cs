namespace _03._Square_Area
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.Write("Ваведи страната на квадрата ");
            int a = int.Parse(Console.ReadLine());
            int area = a * a;

            Console.Write("Лицето на квадрата е ");
            Console.WriteLine(area);

        }
    }
}
