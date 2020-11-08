namespace FoodShortage.Contracts
{
    public interface Person : IBuyer
    {
        public string Name { get; }
        public int Age { get; }
    }
}
