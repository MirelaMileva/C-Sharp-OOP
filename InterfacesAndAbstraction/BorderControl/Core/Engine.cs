namespace BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Contracts;
    public class Engine
    {
        private List<IIdentifiable> identifiables;
        public Engine()
        {
            identifiables = new List<IIdentifiable>();
        }
        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] inputArgs = command.Split().ToArray();

                if (inputArgs[0].All(ch => char.IsLetter(ch)))
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];

                    Citizen citizen = new Citizen(name, age, id);
                    identifiables.Add(citizen);
                }
                else if (inputArgs[0].Any(ch => char.IsLetterOrDigit(ch)))
                {
                    string model = inputArgs[0];
                    string id = inputArgs[1];

                    Robot robot = new Robot(model, id);
                    identifiables.Add(robot);
                }
            }

            string fakeIdNumbers = Console.ReadLine();

            foreach (var identifiable in this.identifiables)
            {
                if (identifiable.Id.EndsWith(fakeIdNumbers))
                {
                    Console.WriteLine(identifiable.Id);
                }
            }
        }
    }
}
