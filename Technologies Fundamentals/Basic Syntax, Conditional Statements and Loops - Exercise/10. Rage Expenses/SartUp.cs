namespace _10._Rage_Expenses
{
    using System;

    class SartUp
    {
        static void Main(string[] args)
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
