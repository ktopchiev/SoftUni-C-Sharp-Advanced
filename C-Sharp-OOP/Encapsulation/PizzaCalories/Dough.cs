using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double white = 1.5,
            wholegrain = 1.0,
            crispy = 0.9,
            chewy = 1.1,
            homemade = 1.0;

        private const double baseCalories = 2;
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
                if (value >= 1 && value <= 200)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

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
                    flourTypeValue = white; 
                    break;
                case "wholegrain":
                    flourTypeValue = wholegrain;
                    break;
                default:
                    break;
            }

            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    bakingTechniqueValue = crispy;
                    break;
                case "chewy":
                    bakingTechniqueValue = chewy;
                    break;
                case "homemade":
                    bakingTechniqueValue = homemade;
                    break;
                default:
                    break;

            }

            return (baseCalories * weight) * flourTypeValue * bakingTechniqueValue;
        }
    }
}
