using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISpecialSoldier
    {
        public IReadOnlyList<IMission> Missions { get; }

        void AddMission(IMission mission);
    }
}
