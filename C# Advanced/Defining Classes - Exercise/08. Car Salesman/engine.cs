using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public List<Engine> engines;
        public string ModelEngine { get; set; }
        public string Power { get; set; } 
        public string Displacement { get; set; } 
        public string Efficiency { get; set; } 

        public Engine(string modelEngine, string power, int displacement, char efficincy)
        {
            ModelEngine = modelEngine;
            Power = power;
            Displacement = displacement.ToString();
            Efficiency = efficincy.ToString();
        }

        public Engine(string modelEngine, string power, char efficincy)
        {
            ModelEngine = modelEngine;
            Power = power;
            Displacement = "n/a";
            Efficiency = efficincy.ToString();
        }

        public Engine(string modelEngine, string power, int displacement)
        {
            ModelEngine = modelEngine;
            Power = power;
            Displacement = displacement.ToString();
            Efficiency = "n/a";
        }

        public Engine(string modelEngine, string power)
        {
            ModelEngine = modelEngine;
            Power = power;
            Displacement = "n/a";
            Efficiency = "n/a";
        }

        public Engine()
        {
            engines = new List<Engine>();
        }
    }
}
