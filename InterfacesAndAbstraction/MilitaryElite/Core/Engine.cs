namespace MilitaryElite.Core
{
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] inputInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string result = commandInterpreter.Read(inputInfo);

                    Console.WriteLine(result);
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}
