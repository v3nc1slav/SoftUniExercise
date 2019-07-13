namespace AnimalFarm
{
    using System;

    public class Pizza
    {
        private string name;
        private double gramsDough;
        private double gramsTopping;
        private string  topping;
        public double result { get; set; } = 0;


        public Pizza(string name, string dough, string bakingTechnique, Double grams)
        {
            Name = name;
            Dough Dough = new Dough(dough);
            BakingTechnique BakingTechnique = new BakingTechnique(bakingTechnique);
            GramsDough = grams;
            result = (2.0 * grams) * Dough.CalcoleitDought(dough)
                * BakingTechnique.CalcoleitBakingTechnique(bakingTechnique);
        }

        public Pizza( string topping, Double grams)
        {
            Topping Topping = new Topping(topping);
            this.topping = topping;
            GramsTopping = grams;
            result = (2.0 * grams) * Topping.CalcoleitTopping(topping);
        }

        public Pizza()
        {
            
        }

        public double GramsDough
        {
            get => gramsDough;
            private set
            {
                if (value<1||200<value)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                gramsDough = value;
            }
        }

        public double GramsTopping
        {
            get => gramsTopping;
            private set
            {
                if (value <= 1 || 50 < value)
                {
                    throw new ArgumentException($"{topping} weight should be in the range [1..50].");
                }
                gramsTopping = value;
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < 1 || 15 <= value.Length)
                {
                    throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

    }
}
