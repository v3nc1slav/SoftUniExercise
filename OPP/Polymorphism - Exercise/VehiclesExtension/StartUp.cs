namespace VehiclesExtension
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var engin = new Engin.Engin();
            engin.Command(int.Parse(Console.ReadLine()));
            engin.Print();
        }
    }
}
