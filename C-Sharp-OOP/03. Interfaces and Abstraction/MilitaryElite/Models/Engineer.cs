using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialSoldier, IEngineer
    {
        private List<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
           repairs = new List<IRepair>();
        }

        public IReadOnlyList<IRepair> Repairs { get => repairs.AsReadOnly(); }

        public void AddRepair(IRepair repair) => repairs.Add(repair);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(
                $"{base.ToString()}{Environment.NewLine}" +
                $"Repairs:{Environment.NewLine}");

            foreach (var repair in repairs)
            {
                sb.Append("  ").Append($"{repair}").AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
