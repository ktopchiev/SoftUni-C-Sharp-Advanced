using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {

        public Mission(string codeName, MissionState state)
        {
            MissionState = state;
            CodeName = codeName;
        }

        public string CodeName { get; private set; }

        public MissionState MissionState { get; private set; }


        public void CompleteMission()
        {
            MissionState = MissionState.Finished;
        }

        public override string ToString()
        {
            return ($"Code Name: {CodeName} State: {MissionState}").TrimEnd();
        }
    }
}
