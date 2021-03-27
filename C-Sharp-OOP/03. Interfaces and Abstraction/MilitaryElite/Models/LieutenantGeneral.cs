using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;
        private object @private;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privates = new List<IPrivate>();
        }

        public IReadOnlyList<IPrivate> Privates { get => privates; }

        public void AddPrivate(IPrivate @private) => privates.Add(@private);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(
                $"{base.ToString()}{Environment.NewLine}" +
                $"Privates:{Environment.NewLine}");

            foreach (var souja in privates)
            {
                sb.Append("  ").Append(souja.ToString()).AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

    }
}
