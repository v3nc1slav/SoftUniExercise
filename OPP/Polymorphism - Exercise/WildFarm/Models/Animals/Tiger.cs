
namespace WildFarm.Models
{
    using System.Collections.Generic;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight,  string livingRegion, string breed)
            : base(name, weight,  livingRegion, breed)
        {

        }

        public List<string> foods = new List<string>() { "Meat"};

        public string Speaks()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public override void Eaten(int foodEaten)
        {

            FoodEaten = foodEaten;
            double a = FoodEaten * 1;
            Weight += a;
        }
    }
}
