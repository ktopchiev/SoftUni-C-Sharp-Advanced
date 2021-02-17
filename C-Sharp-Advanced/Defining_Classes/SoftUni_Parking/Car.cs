﻿using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Make: {Make}").AppendLine();
            sb.Append($"Model: {Model}").AppendLine();
            sb.Append($"HorsePower: {HorsePower}").AppendLine();
            sb.Append($"RegistrationNumber: {RegistrationNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}