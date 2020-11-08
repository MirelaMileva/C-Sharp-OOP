namespace FoodShortage.Core
{
    using FoodShortage.Contracts;
    using FoodShortage.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Engine
    {
        private List<Person> people;

        public Engine()
        {
            this.people = new List<Person>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                { 
                    string id = input[2];
                    string birthdate = input[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate, 0);
                    people.Add(citizen);
                }
                else
                {
                    string group = input[2];

                    Rebel rebel = new Rebel(name, age, group, 0);
                    people.Add(rebel);
                }

            }

            string personName;
            while ((personName = Console.ReadLine()) != "End")
            {
                foreach (var person in people)
                {
                    if (person.Name == personName)
                    {
                        person.BuyFood();
                    }
                }
                
            }

            Console.WriteLine(people.Sum(p => p.Food));
        }
    }
}
