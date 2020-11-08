using System;
using System.Linq;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputInfo = input
                    .Split()
                    .ToArray();

                string name = inputInfo[0];
                string country = inputInfo[1];
                int age = int.Parse(inputInfo[2]);
                Citizen citizen = new Citizen(name,country, age);
                IPerson citizenName = citizen;
                IResident residentName = citizen;
                Console.WriteLine(citizenName.GetName());
                Console.WriteLine(residentName.GetName());
            }
        }
    }
}
