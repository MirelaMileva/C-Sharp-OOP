using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private List<Product> products;
        private List<Person> people;

        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }

        public void Run()
        {
            AddPeople();
            AddProduct();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split().ToArray();

                string personName = commandArgs[0];
                string productName = commandArgs[1];

                try
                {
                    Person person = this.people.First(p => p.Name == personName);

                    Product product = this.products.First(p => p.Name == productName);

                    person.AddProduct(product);

                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            foreach (Person person in this.people)
            {
                Console.WriteLine(person);
            }
        }

        private void AddProduct()
        {
            string[] productArgs = Console.ReadLine()
                .Split(";")
                .ToArray();

            for (int i = 0; i < productArgs.Length; i++)
            {
                string[] currProduct = productArgs[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currProduct[0];
                decimal cost = decimal.Parse(currProduct[1]);

                Product product = new Product(name, cost);

                this.products.Add(product);
            }
        }

        private void AddPeople()
        {
            string[] peopleArgs = Console.ReadLine()
                .Split(";")
                .ToArray();

            for (int i = 0; i < peopleArgs.Length; i++)
            {
                string[] currPeople = peopleArgs[i]
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = currPeople[0];
                decimal money = decimal.Parse(currPeople[1]);

                Person person = new Person(name, money);
                this.people.Add(person);
            }
        }
    }
}
