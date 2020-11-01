using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    public class StudentSystem
    {
         public Dictionary<string, Student> Students { get; } = new Dictionary<string, Student>();

        public void Add(string name, int age, double grade)
        {
            if (!this.Students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.Students[name] = student;
            }
        }

        public string GetDetails(string name)
        {
            if (this.Students.ContainsKey(name))
            {
                var student = this.Students[name];
                string details = $"{student.Name} is {student.Age} years old.";

                if (student.Grade >= 5.00)
                {
                    details += " Excellent student.";
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    details += " Average student.";
                }
                else
                {
                    details += " Very nice person.";
                }

                return details;
            }

            return null;
        }
    }
}
