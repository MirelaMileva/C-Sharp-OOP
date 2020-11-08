namespace FoodShortage.Models
{
    using Contracts;
    public class Rebel : Person, IBuyer
    {
        public Rebel(string name, int age, string group, int food)
        {
            this.Name = name;
            this.Age = age;
            this.Food = food;
            this.Group = group;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Food { get; private set; }
        public string Group { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
