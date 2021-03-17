using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialSoldier, IEngineer
    {
        private Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
           Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get; set; }

        //Factory pattern
        public static Engineer NewEngineer(int id, string firstName, string lastName, decimal salary, string corps)
        {
            if (corps != "Airforces" && corps != "Marines")
            {
                return null;
            }

            return new Engineer(id, firstName, lastName, salary, corps);
        }

        public void AddRepair(Repair repair) => Repairs.Add(repair);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(
                $"{base.ToString()}{Environment.NewLine}" +
                $"Repairs:{Environment.NewLine}");

            foreach (var repair in Repairs)
            {
                sb.Append("  ").Append($"{repair.ToString()}").AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
