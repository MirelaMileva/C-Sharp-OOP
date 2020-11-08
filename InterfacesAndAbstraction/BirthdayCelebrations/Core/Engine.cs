namespace BirthdayCelebrations.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;

    public class Engine
    {
        private List<IBirthable> birthdates;
        public Engine()
        {
            this.birthdates = new List<IBirthable>();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                ReadInput(input);
            }

            string birthYear = Console.ReadLine();

            PrintOutput(birthYear);
        }

        private void PrintOutput(string birthYear)
        {
            foreach (IBirthable birthable in this.birthdates)
            {
                if (birthable.Birthdate.EndsWith(birthYear))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }

        private void ReadInput(string input)
        {
            var inputInfo = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string type = inputInfo[0];

            if (type == "Citizen")
            {
                string name = inputInfo[1];
                int age = int.Parse(inputInfo[2]);
                string id = inputInfo[3];
                string birthdate = inputInfo[4];

                Citizen citizen = new Citizen(name, age, id, birthdate);
                birthdates.Add(citizen);
            }
            else if (type == "Robot")
            {
                string model = inputInfo[1];
                string id = inputInfo[2];

                Robot robot = new Robot(model, id);
            }
            else if (type == "Pet")
            {
                string name = inputInfo[1];
                string birthdate = inputInfo[2];

                Pet pet = new Pet(name, birthdate);
                birthdates.Add(pet);
            }
        }
    }
}