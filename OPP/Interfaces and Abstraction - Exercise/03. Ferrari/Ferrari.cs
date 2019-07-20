using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string name)
        {
            NameDriver = name;
        }

        public string Model { get; private set; } = "488-Spider";

        public string NameDriver { get; set; }

        public string Gas()
        {
            return "Gas!";
        }

        string IFerrari.Brakes()
        {
          return  "Brakes!";
        }
    }
}
