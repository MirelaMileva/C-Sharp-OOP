namespace WildFarm.Models.Foods
{
    using WildFarm.Models.Foods.Contracts;
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; }
    }
}
