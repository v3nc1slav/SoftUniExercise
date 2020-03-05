namespace _04._Inches_to_Centimeters
{
    using System;
    class StarUp
    {
        static void Main(string[] args)
        {
            Double inches = Double.Parse(Console.ReadLine());
            double centimeters = inches * 2.54;
            Console.WriteLine(centimeters);
        }
    }
}
