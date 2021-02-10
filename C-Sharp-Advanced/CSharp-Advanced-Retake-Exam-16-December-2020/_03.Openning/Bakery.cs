using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public string Name { get; set; }
        private int capacity;
        public List<Employee> Employees;
        public int Count => Employees.Count;

        public Bakery(string name, int capacity)
        {
            Name = name;
            this.capacity = capacity;
            Employees = new List<Employee>(capacity);
        }

        public void Add(Employee employee)
        {
            if (Employees.Count < capacity)
            {
                Employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Predicate<Employee> empl = empl => empl.Name == name;
            bool isExist = Employees.Exists(empl);
            Employees.RemoveAll(empl);
            return isExist;
        }

        public Employee GetOldestEmployee()
        {
            Employees.OrderByDescending(x => x.Age);
            return Employees.FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return Employees.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Employees working at a Bakery {Name}").AppendLine();

            foreach (var employee in Employees)
            {
                sb.Append($"{employee}").AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
        
    }
}