using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Login
{
    public class Program
    {
        public static void Main()
        {
            string User = Console.ReadLine();
            string Password = string.Empty;
            int counter = 0;
            for (int i = User.ToString().Length - 1; i >= 0; i--)
            {
                char input = User.ToString()[i];
                Password += input;
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == Password)
                {
                    Console.WriteLine($"User {User} logged in.” ");
                    return;
                }
                else
                {
                    if (counter == 3)
                    {
                        Console.WriteLine($"User {User} blocked!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                        counter++;
                    }
                }
            }
        }
    }
}