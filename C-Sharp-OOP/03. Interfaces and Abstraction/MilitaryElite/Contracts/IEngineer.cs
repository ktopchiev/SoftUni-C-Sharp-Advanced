using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialSoldier
    {
        public IReadOnlyList<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
