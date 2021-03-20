using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialSoldier : Private, ISpecialSoldier
    {

        protected SpecialSoldier(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        {
            return ($"{base.ToString()} {Environment.NewLine}" +
                $"Corps: {Corps}").TrimEnd();
        }
    }
}
