using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.Birthday_Celebrations
{
    public class BirthdayCelebrations : IPet, ICitizens, IRobots
    {
        List<string> birthdays = new List<string>();

        public void Birthdates(string name, string birthday)
        {
            birthdays.Add(birthday);
        }

        public void Birthdates(string name, string age, string id, string birthday)
        {
            birthdays.Add(birthday);
        }

        public void Birthdates(string model, int id)
        {
            
        }

        public void Celebrations(string specificYear)
        {
            for (int i = 0; i < birthdays.Count; i++)
            {
                string birthday = string.Empty;
                for (int j = birthdays[i].Length - specificYear.Length; j < birthdays[i].Length; j++)
                {
                    birthday += birthdays[i][j];
                }

                if (specificYear == birthday)
                {
                    Console.WriteLine($"{birthdays[i]}");
                }
            }
        }
    }
}
