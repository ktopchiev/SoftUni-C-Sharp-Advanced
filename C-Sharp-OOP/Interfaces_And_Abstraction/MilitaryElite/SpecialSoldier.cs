using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialSoldier : Private, ISpecialSoldier
    {
        private string corps;

        protected SpecialSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps
        {
            get => corps;

            private set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    corps = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Environment.NewLine}" +
                $"Corps: {Corps}";
        }
    }
}
