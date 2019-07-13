namespace AnimalFarm
{
    using System;

    public class Dough
    {
        public double white { get; set; } = 1.5;
        public double wholegrain { get; set; } = 1.0;
        

        public Dough(string dought)
        {
            dought = dought.ToLower();
            if (dought != "white"
                && dought != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }

        public double CalcoleitDought(string dought)
        {
            dought = dought.ToLower();
            if (dought == "white")
            {
                return white;
            }
            else
            {
                return wholegrain;
            }
        }

    }
}
