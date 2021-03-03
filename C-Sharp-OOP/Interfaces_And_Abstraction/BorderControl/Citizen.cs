using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable, IBirthable
    {
        private string name;
        private string id;
        private int age;
        private string birthdate;

        public Citizen(string name, string id, int age, string birthdate)
        {
            Name = name;
            Id = id;
            Age = age;
            Birthdate = birthdate;
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
    }
}
