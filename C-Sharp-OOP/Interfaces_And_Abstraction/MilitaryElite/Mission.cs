using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        private string state;
        private string codeName;

        private Mission(string codeName, string state)
        {
            State = state;
            CodeName = codeName;
        }

        public string CodeName
        {
            get => codeName;

            private set
            {
                if (state == "inProgress" || state == "Finished")
                {
                    codeName = value;
                }
            }
        }

        public string State
        {
            get => state;

            private set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    state = value;
                }
            }
        }

        public static Mission Create(string codeName, string state)
        {
            if (state != "inProgress" && state != "Finished")
            {
                return null;
            }

            return new Mission(codeName, state);
        }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {state}";
        }
    }
}
