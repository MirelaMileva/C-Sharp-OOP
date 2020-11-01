using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    public class Student
    {
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

    }
}

