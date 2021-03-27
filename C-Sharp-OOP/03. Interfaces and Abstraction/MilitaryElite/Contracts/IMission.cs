using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }

        public MissionState MissionState { get; }

        void CompleteMission();
    }
}
