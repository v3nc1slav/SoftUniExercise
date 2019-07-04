using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Lizard lizard = new Lizard(Console.ReadLine());
            Console.WriteLine(lizard.Name);
        }
    }
}