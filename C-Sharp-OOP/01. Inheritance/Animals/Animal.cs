using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            try
            {
                Name = name;
                Age = age;
                Gender = gender;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }

        public string Name { get; set; }

        public int Age { get; set;}

        public virtual string Gender { get; set; }

        public virtual void ProduceSound()
        {
            
        }
    }
}
