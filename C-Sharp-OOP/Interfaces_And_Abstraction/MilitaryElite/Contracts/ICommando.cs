using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ICommando
    {
        public List<Mission> Missions { get; }
    }
}
