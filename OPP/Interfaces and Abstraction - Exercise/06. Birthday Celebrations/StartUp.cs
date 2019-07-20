using System;
using System.Linq;
using PersonInfo.Birthday_Celebrations;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BirthdayCelebrations birthday = new BirthdayCelebrations();

            var command = Console.ReadLine().Split().ToArray();
            while (command[0] != "End")
            {
                if (command[0] == "Citizen")
                {
                    birthday.Birthdates(command[1],command[2], command[3], command[4]);
                }
                else if(command[0] == "Robot")
                {
                    birthday.Birthdates(command[1], int.Parse(command[2]));
                }
                else if (command[0] == "Pet")
                {
                    birthday.Birthdates(command[1], command[2]);
                }
                command = Console.ReadLine().Split().ToArray();
            }
            birthday.Celebrations(Console.ReadLine());
        }
    }
}
