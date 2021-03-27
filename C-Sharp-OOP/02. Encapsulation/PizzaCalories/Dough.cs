using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double MinRange = 1;
        private const double MaxRange = 200;

        private const double White = 1.5,
            Wholegrain = 1.0,
            Crispy = 0.9,
            Chewy = 1.1,
            Homemade = 1.0;
        private const double BaseCalories = 2;
        private const string InvalidTypeMessage = "Invalid type of dough.";

        private double weight;
        private string flourType;
        private string bakingTechnique;

        public Dough()
        {

        }

        public Dough(double weight, string flourType, string bakingTech)
            : this()
        {
            Weight = weight;
            FlourType = flourType;
            BakingTechnique = bakingTech;
        }

        private double Weight
        {
            set
            {
                Validator.ThrowIfNumberIsNotInRange(MinRange, MaxRange, value, $"Dough weight should be in the range[{MinRange}..{MaxRange}].");

                weight = value;
            }
        }

        private string FlourType
        {
            set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "white", "wholegrain"}, value.ToLower(), InvalidTypeMessage);

                flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string> { "crispy", "chewy", "homemade" }, value.ToLower(), InvalidTypeMessage);

                bakingTechnique = value;
            }
        }

        public double GetTotalCalories()
        {
            double flourTypeValue = 0.0;
            double bakingTechniqueValue = 0.0;

            switch (flourType.ToLower())
            {
                case "white":
                    flourTypeValue = White; 
                    break;
                case "wholegrain":
                    flourTypeValue = Wholegrain;
                    break;
                default:
                    break;
            }

            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    bakingTechniqueValue = Crispy;
                    break;
                case "chewy":
                    bakingTechniqueValue = Chewy;
                    break;
                case "homemade":
                    bakingTechniqueValue = Homemade;
                    break;
                default:
                    break;

            }

            return (BaseCalories * weight) * flourTypeValue * bakingTechniqueValue;
        }
    }
}
