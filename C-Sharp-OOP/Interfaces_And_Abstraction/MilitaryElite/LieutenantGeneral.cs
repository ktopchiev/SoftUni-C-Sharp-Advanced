using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, int[] privatesIds)
            : base(id, firstName, lastName, salary)
        {
            PrivatesIds = privatesIds.ToHashSet();
            privates = new List<Private>();
        }

        public HashSet<int> PrivatesIds { get; set;}

        public void AddPrivates(List<Private> inputPrivates)
        {
            foreach (var soldier in inputPrivates)
            {
                var souja = soldier;

                if (PrivatesIds.Contains(soldier.Id))
                {
                    privates.Add(souja);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(
                $"{base.ToString()}{Environment.NewLine}" +
                $"Privates:{Environment.NewLine}");

            foreach (var souja in privates)
            {
                sb.Append("  ").Append(souja.ToString()).AppendLine();
            }

            return sb.ToString().Trim();
        }

    }
}
