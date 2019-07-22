
namespace WildFarm.Models
{
    using System.Collections.Generic;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight,  livingRegion)
        {

        }

        public List<string> foods = new List<string>() { "Fruit", "Vegetable" };

        public string Speaks()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public override void Eaten(int foodEaten)
        {

            FoodEaten = foodEaten;
            double a = FoodEaten * 0.1;
            Weight += a;
        }
    }
}
