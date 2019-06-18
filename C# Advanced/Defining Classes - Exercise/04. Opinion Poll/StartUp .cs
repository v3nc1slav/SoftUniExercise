using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var oldPersons = new SortedDictionary<string,int>();
            for (int i = 0; i < number; i++)
            {
                Person person = new Person();
                var command = Console.ReadLine().Split();
                string name = command[0];
                int age = int.Parse(command[1]);
                person.Name = name;
                person.Age = age;
                if (person.Age > 30)
                {
                    oldPersons.Add(person.Name,person.Age);
                }
            }
            foreach (var (key, value) in oldPersons)
            {
                Console.Write($"{key} - {value}");
                Console.WriteLine();
            }
        }
    }
}
