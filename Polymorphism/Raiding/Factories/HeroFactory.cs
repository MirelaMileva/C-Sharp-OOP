namespace Raiding.Factories
{
    using Raiding.Models;
    using System;

    public class HeroFactory
    {
        private const string INVALID_HERO = "Invalid hero!";
        public BaseHero Create(string heroName, string heroType)
        {
            BaseHero hero = null;

            if (heroType == "Druid")
            {
                int power = 80;
                hero = new Druid(heroName, power);
            }
            else if (heroType == "Paladin")
            {
                int power = 100;
                hero = new Paladin(heroName, power);
            }
            else if (heroType == "Rogue")
            {
                int power = 80;
                hero = new Rogue(heroName, power);
            }
            else if (heroType == "Warrior")
            {
                int power = 100;
                hero = new Warrior(heroName, power);
            }
            else
            {
                throw new InvalidOperationException(INVALID_HERO);
            }

            return hero;
        }
    }
}
