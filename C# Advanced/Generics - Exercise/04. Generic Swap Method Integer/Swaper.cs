using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Generic_Swap_Method_Integer
{
    public class Swaper<T>
    {
        private List<T> itemsList;
        public Swaper()
        {
            itemsList = new List<T>();
        }
        public Swaper(List<T> items, int first, int second)
        {
            T elementToSwap = items[first];
            T elementSwapWith = items[second];
            items[first] = elementSwapWith;
            items[second] = elementToSwap;
            itemsList = items;
        }

        public List<T> GetList()
        {
            return itemsList;
        }
    }
}
