using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAdoStudent
{
    public class Student
    {
        private int id;
        private string name;
        private int age;
        private decimal grade;

        public int ID
        {
            get { return id; }
            set
            {
                if (value < 0) Console.WriteLine("Enter corret id");
                else id = value;

            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value)) Console.WriteLine("Enter correct name");
                else name = value;
            }
        }
        public decimal Grade
        {
            get { return grade; }
            set
            {
                if (value < 0 || value > 100) Console.WriteLine("Enter correct grade");
                else grade = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 && value > 60) Console.WriteLine("Enter correct age");
                else age = value;
            }
        }

    }
}
