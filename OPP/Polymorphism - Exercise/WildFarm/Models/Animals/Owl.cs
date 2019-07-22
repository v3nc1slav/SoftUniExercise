
namespace WildFarm.Models
{
    using System.Collections.Generic;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double windSize)
            : base(name, weight,  windSize)
        {

        }

        public List<string> foods = new List<string>() { "Meat" };

        public string Speaks()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }

        public override void Eaten(int foodEaten)
        {
            FoodEaten = foodEaten;
            double a = FoodEaten * 0.25;
            Weight += a;
        }
    }
}
