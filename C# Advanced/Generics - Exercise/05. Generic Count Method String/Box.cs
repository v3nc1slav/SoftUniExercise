using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Generic_Count_Method_String
{
    public class Box<T> where T : IComparable
    {
        private List<T> itemsList;
        private int count;

        public Box()
        {
            itemsList = new List<T>();
            count = 0;
        }
        public Box(List<T> items, string compareTo) : this()
        {
            itemsList = items;

            foreach (var item in itemsList)
            {
                if (item.CompareTo(compareTo) > 0)
                {
                    count++;
                }
            }
        }

        public int GetCount()
        {
            return count;
        }

    }
}
