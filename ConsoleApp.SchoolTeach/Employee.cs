using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.SchoolTeach
{
    public class Employee
    {
        int id;
        string name;
        float salary;
        public Employee(int id, string name, float salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
        public void display()
        {
            Console.WriteLine(id + "" + name + "" + salary);
        }
    }
}
