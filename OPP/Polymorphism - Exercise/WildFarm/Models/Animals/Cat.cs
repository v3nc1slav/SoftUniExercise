
namespace WildFarm.Models
{
    using System.Collections.Generic;

    public class Cat : Feline
    {
        public Cat(string name, double weight,  string livingRegion, string breed)
            : base(name, weight,  livingRegion, breed)
        {

        }

        public List<string> foods = new List<string>() {"Meat", "Vegetable" };

        public string Speaks()
        {
            return "Meow";
        } 

        public override string ToString()
        {
            return ($"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]");
        }

        public override void Eaten(int foodEaten)
        {
            FoodEaten = foodEaten;
            double a = FoodEaten* 0.3;
            Weight += a;
        }
    }
}
