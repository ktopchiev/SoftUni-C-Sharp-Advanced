﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string gender = "Female";

        public Kitten(string name, int age)
            : base(name, age, null)
        {

        }

        public override string Gender { get => gender; }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
