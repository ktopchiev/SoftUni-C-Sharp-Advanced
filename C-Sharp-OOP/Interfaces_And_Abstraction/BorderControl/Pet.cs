﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBirthable
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get => name; private set => name = value; }

        public string Birthdate { get => birthdate; private set => birthdate = value; }
        
    }
}
