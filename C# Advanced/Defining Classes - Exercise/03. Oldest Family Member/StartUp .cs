using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < number; i++)
            {
                Person person = new Person();
                var command = Console.ReadLine().Split();
                string name = command[0];
                int age = int.Parse(command[1]);
                person.Name = name;
                person.Age = age;
                family.AddMember(person);
            }
            var oldPerson = family.GetOldestMember();
            Console.WriteLine(oldPerson.Name + " " + oldPerson.Age);
        }
    }
}
