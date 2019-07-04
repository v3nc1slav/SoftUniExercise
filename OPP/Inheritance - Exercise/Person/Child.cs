using System;

namespace Person
{
    public class Child : Person
    {

        public Child(string name, int age)
            : base(name, age)
        {


        }

        public override int Age
        {
            get { return base.Age; }
            protected set
            {
               // if (value > 15)
               // {
               //     throw new ArgumentException("Children should not be able to have an age more than 15.");
               // }

                base.Age = value;
            }
        }
    }
}
