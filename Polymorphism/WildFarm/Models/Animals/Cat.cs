namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Models.Foods;
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightMultiplier => 0.30;

        public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}