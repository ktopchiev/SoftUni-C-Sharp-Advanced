using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private string name;
        private string id;
        private int age;
        private string birthdate;
        private int food;

        public Citizen(string name, string id, int age, string birthdate, int food = 0)
        {
            Name = name;
            Id = id;
            Age = age;
            Birthdate = birthdate;
            Food = food;
        }

        public string Name
        {
            get => name;

            private set
            {
                name = value;
            }
        }

        public string Id
        {
            get => id;

            private set
            {
                id = value;
            }
        }
        public int Age
        {
            get => age;

            set
            {
                age = value;
            }
        }

        public string Birthdate { get => birthdate; private set => birthdate = value; }

        public int Food { get => food; private set => food = value;}

        public void BuyFood()
        {
            food += 10;
        }
    }
}
