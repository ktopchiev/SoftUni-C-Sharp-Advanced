using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyList<IMission> Missions { get => missions.AsReadOnly(); }

        public void AddMission(IMission mission) => missions.Add(mission);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(
                $"{base.ToString()}{Environment.NewLine}" +
                $"Missions:{Environment.NewLine}");

            foreach (var mission in missions)
            {
                sb.Append("  ").Append($"{mission}").AppendLine();
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
