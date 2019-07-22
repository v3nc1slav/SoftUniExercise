namespace WildFarm.Models.Food
{
    public abstract class Food 
    {
        public int Quantity { get; set; }

        public Food(int quantity)
        {
            Quantity = quantity;
        }

    }
}
