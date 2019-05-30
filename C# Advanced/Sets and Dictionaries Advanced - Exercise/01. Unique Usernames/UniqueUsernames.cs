using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Unique_Usernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            PrintUniqueUsernames();
        }

        private static void PrintUniqueUsernames()
        {
            var number = int.Parse(Console.ReadLine());
            var userName = new HashSet<string>();
            for (int i = 0; i < number; i++)
            {
                userName.Add(Console.ReadLine());
            }
            foreach (var item in userName)
            {
                Console.WriteLine(item);
            }
        }
    }
}
