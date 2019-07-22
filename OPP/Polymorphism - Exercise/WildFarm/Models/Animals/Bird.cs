namespace WildFarm.Models
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; set; }

        public Bird(string name, double weight,  double windSize) 
            : base(name, weight)
        {
            WingSize = windSize;
        }

    }
}
