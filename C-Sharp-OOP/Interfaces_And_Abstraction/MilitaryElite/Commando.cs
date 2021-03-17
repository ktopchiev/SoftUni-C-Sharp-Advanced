using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialSoldier, ICommando
    {

        private Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; set; }

        //Factory pattern
        public static Commando NewCommando(int id, string firstName, string lastName, decimal salary, string corps)
        {
            if (corps != "Airforces" && corps != "Marines")
            {
                return null;
            }

            return new Commando(id, firstName, lastName, salary, corps);
        }

        public void AddMission(Mission mission)
        {
            Missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(
                $"{base.ToString()}{Environment.NewLine}" +
                $"Missions:{Environment.NewLine}");

            if (Missions != null)
            {
                foreach (var mission in Missions.Where(x => x != null))
                {
                    sb.Append("  ").Append($"{mission.ToString()}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
