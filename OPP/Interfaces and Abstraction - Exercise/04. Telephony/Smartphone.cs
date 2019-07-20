using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PersonInfo
{
    public class Smartphone : IPhones, IWeb
    {
        public Smartphone()
        {
           
        }

        public string CallingPhones(string phonesNumber)
        {
            if (!phonesNumber.All(c=>char.IsDigit(c)))
            {
               throw  new ArgumentException($"Invalid number!");
            }
            return ($"Calling... {phonesNumber}");
        }

        public string Browsing(string web)
        {
            if (web.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return ($"Browsing: {web}!");
        }

        string IWeb.Browsing(string web)
        {
            throw new NotImplementedException();
        }
    }
}
