namespace WildFarm.Models
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }

        public Mammal(string name, double weight,  string livingRegion)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public override void Eaten(int foodEaten)
        {
            FoodEaten = foodEaten ;
            Weight += FoodEaten;
        }
    }
}
