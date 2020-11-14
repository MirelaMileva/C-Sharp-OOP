namespace Raiding.Core
{
    using Raiding.Core.Contracts;
    using Raiding.Factories;
    using Raiding.Models;
    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private readonly ICollection<BaseHero> heros;

        private readonly HeroFactory heroFactory;

        public Engine()
        {
            this.heros = new List<BaseHero>();
            this.heroFactory = new HeroFactory();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                while (counter != n)
                {
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();

                    BaseHero hero = null;

                    try
                    {
                        hero = this.heroFactory.Create(heroName, heroType);
                        this.heros.Add(hero);
                        counter++;
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                }
  
            }

            int bossPower = int.Parse(Console.ReadLine());

            int herosPower = 0;
            try
            {
                if (heros != null)
                {
                    foreach (BaseHero currHero in heros)
                    {
                        Console.WriteLine(currHero.CastAbility());
                        herosPower += currHero.Power;
                    }
                }
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            
            if (herosPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
