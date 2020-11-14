namespace Raiding.Models
{
    using Contracts;
    public class Warrior : BaseHero
    {
        public Warrior(string name, int power) 
            : base(name, power)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}