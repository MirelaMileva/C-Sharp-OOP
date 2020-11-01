using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    public class Engine
    {
        private StudentSystem studentData;

        public Engine()
        {
            this.studentData = new StudentSystem();
        }
        public void Process()
        {
            var end = false;
            while (!end)
            {
                var line = Console.ReadLine();

                var command = Command.Parse(line);
                var arguments = command.Arguments;
                switch (command.Name)
                {
                    case "Create":
                        this.studentData.Add(arguments[0], int.Parse(arguments[1]), double.Parse(arguments[2]));
                        break;
                    case "Show":
                        var details = this.studentData.GetDetails(arguments[0]);
                        Console.WriteLine(details);
                        break;
                    case "Exit":
                        end = true;
                        break;
                }
            }
        }
    }
}
