using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight hero = new BladeKnight(Console.ReadLine(), int.Parse(Console.ReadLine()));
            Console.WriteLine(hero);
        }
    }
}