
namespace WildFarm.Models
{
using System.Collections.Generic;
    public class Hen : Bird
    {
        public Hen(string name, double weight,  double windSize) 
            : base(name, weight,  windSize)
        {

        }

        public  List<string> foods = new List<string>() { "Fruit", "Meat", "Seeds", "Vegetable" };

        public string Speaks()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }

        public override void Eaten(int foodEaten)
        {
            FoodEaten = foodEaten;
            double a = FoodEaten * 0.35;
            Weight += a;
        }
    }
}
