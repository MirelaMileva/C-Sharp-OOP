using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomException
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name 
        { 
            get
            {
                return this.name;
            }
            private set
            {
                if (!(value.All(ch => Char.IsDigit(ch))))
                {
                    throw new InvalidPersonNameException("The name cannot contains digits or special characters!");
                }

                this.name = value;
            }
        }
        public string Email { get; private set; }
    }
}
