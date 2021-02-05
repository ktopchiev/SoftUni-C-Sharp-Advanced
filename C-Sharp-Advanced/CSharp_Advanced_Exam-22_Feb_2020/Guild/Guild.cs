using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Player> Roster { get; set; }

        public int Count => Roster.Count;


        public Guild(string guildName, int guildCapacity)
        {
            Name = guildName.Trim();
            Capacity = guildCapacity;
            Roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (Roster.Count < Capacity)
            {
                Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            bool NameForRemoving(Player playerName) => playerName.Name == name;
            bool isRemoved = Roster.Exists(NameForRemoving);

            if (isRemoved)
            {
                Roster.RemoveAll(NameForRemoving);
            }

            return isRemoved;
        }

        public void PromotePlayer(string name)
        {
            bool nameExist = Roster.Exists(player => player.Name == name);
            if (nameExist)
            {
                Player playerForPromoting = Roster.First(player => player.Name == name);
                playerForPromoting.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            bool nameExist = Roster.Exists(player => player.Name == name);
            if (nameExist)
            {
                Player playerForDemoting = Roster.First(player => player.Name == name);
                playerForDemoting.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            Player[] kickedPlayers = Roster.Where(player => player.Class == playerClass).ToArray();
            Roster.RemoveAll(player => player.Class == playerClass);
            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Players in the guild: {Name}").AppendLine();
            
            foreach (var player in Roster)
            {
                sb.Append(player).Append(Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}