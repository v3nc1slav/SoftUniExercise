using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private string Name { get; set; }
        private int age;

        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public virtual int Age
        {
            get { return this.age; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("People should not be able to have a negative age");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.Name}, Age: {this.Age}");

            return sb.ToString();
        }
    }
}
