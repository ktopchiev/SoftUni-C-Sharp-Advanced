using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private string id;
        private int age;

        public Citizen(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
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

    }
}
