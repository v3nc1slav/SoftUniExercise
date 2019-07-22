
namespace WildFarm.Models
{
    using System.Collections.Generic;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight,  livingRegion)
        {

        }

        public List<string> foods = new List<string>() { "Meat" };

        public string Speaks()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        
        public override void Eaten(int foodEaten)
        {
            FoodEaten = foodEaten;
            double a = FoodEaten * 0.4; 
            Weight += a;
        }
    }
}
