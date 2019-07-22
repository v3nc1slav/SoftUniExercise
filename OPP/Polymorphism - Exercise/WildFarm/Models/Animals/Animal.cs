
namespace WildFarm.Models
{

    public abstract class Animal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double FoodEaten { get; set; }

        public Animal(string name, double weight )
        {
            Name = name;
            Weight = weight;
        }

       public  virtual void Eaten(int foodEaten)
        {
            FoodEaten = foodEaten;
            Weight += FoodEaten;
        }
    }
}
