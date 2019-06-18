using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string fristDate = Console.ReadLine();
            string fristsecondDate = Console.ReadLine();

            var modifier = new DateModifier();
            int result = modifier.TimeDifference(fristDate, fristsecondDate);
            Console.WriteLine(Math.Abs(result));

        }
    }
}
