using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person();
            var person1 = new Person(29);
            var person2 = new Person("Venci", 29);
            Console.WriteLine(person.Name +" "  +person.Age);
            Console.WriteLine(person1.Name +" "  +person1.Age);
            Console.WriteLine(person2.Name +" "  +person2.Age);

        }
    }
}
