using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Intro_and_Basic
{
    class Program
    {
        public static void Main()
        {
            double lostGame = double.Parse(Console.ReadLine());
            double priceHeadSet = Double.Parse(Console.ReadLine());
            double priceMouse = Double.Parse(Console.ReadLine());
            double priceKeyboard = Double.Parse(Console.ReadLine());
            double priceDisplay = Double.Parse(Console.ReadLine());
            priceHeadSet = Math.Truncate(lostGame / 2) * priceHeadSet;
            priceMouse = Math.Truncate(lostGame / 3) * priceMouse;
            priceKeyboard = Math.Truncate(lostGame / 6) * priceKeyboard;
            priceDisplay = Math.Truncate(lostGame / 12) * priceDisplay;
            double finalPrice = priceHeadSet + priceMouse + priceKeyboard + priceDisplay;
            Console.WriteLine($"Rage expenses: {finalPrice:f2} lv.");


        }
    }
}