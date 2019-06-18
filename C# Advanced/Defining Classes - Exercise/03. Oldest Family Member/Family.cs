using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public  class Family
    {
        private List<Person> family ;

        public Family()
        {
            family = new List<Person>();
        }

        public void AddMember(Person member)
        {
             family.Add(member);
           // return member;
        }

        public Person GetOldestMember()
        {
            int max = int.MinValue;
            Person person = new Person();
            for (int i = 0; i < family.Count; i++)
            {
                if (family[i].Age > max)
                {
                    max = family[i].Age;
                    person.Name = family[i].Name;
                    person.Age = max;
                }
            }
            return person;
        }
    }
}
