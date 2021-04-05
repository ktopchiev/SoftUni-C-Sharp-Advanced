using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> party;
        private readonly List<Item> itemPool;

        public WarController()
        {
            party = new List<Character>();
            itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            var characterType = args[0];
            var name = args[1];

            if (characterType != "Warrior" && characterType != "Priest")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            Character character = null;

            switch (characterType)
            {
                case "Warrior":
                    character = new Warrior(name);
                    break;
                case "Priest":
                    character = new Priest(name);
                    break;
                default:
                    break;
            }

            party.Add(character);

            return String.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            if (itemName != "FirePotion" && itemName != "HealthPotion")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidItem, itemName));
            }

            Item item = null;

            switch (itemName)
            {
                case "FirePotion":
                    item = new FirePotion();
                    break;
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                default:
                    break;
            }

            itemPool.Add(item);

            return String.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = party.FirstOrDefault(ch => ch.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemPoolEmpty));
            }

            var lastItemInPool = itemPool.Last();
            itemPool.Remove(lastItemInPool);
            character.Bag.AddItem(lastItemInPool);

            return String.Format(SuccessMessages.PickUpItem, characterName, lastItemInPool.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = party.FirstOrDefault(ch => ch.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = null;

            switch (itemName)
            {
                case "FirePotion":
                    item = new FirePotion();
                    break;
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                default:
                    break;
            }

            character.UseItem(item);

            return String.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder charactersForPrint = new StringBuilder();

            var sortedCharacters = party.OrderByDescending(ch => ch.IsAlive).ThenByDescending(ch => ch.Health).ToList();

            foreach (var character in sortedCharacters)
            {
                string status = null;

                if (character.IsAlive)
                {
                    status = "Alive";
                }
                else
                {
                    status = "Dead";
                }

                charactersForPrint.
                    AppendLine($"{character.Name} - " +
                    $"HP: {character.Health}/{character.BaseHealth}, " +
                    $"AP: {character.Armor}/{character.BaseArmor}," +
                    $" Status: {status}");
            }

            return charactersForPrint.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            var attacker = party.FirstOrDefault(character => character.Name == attackerName);
            var receiver = party.FirstOrDefault(character => character.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (attacker is Warrior warrior)
            {
                warrior.Attack(receiver);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            StringBuilder attackResultPrint = new StringBuilder();

            attackResultPrint.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points!" +
                $" {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                attackResultPrint.AppendLine($"{receiverName} is dead!");
            }

            return attackResultPrint.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            var healer = party.FirstOrDefault(character => character.Name == healerName);
            var receiver = party.FirstOrDefault(character => character.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (healer is Priest priest)
            {
                priest.Heal(receiver);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }

            StringBuilder healResultPrint = new StringBuilder();

            healResultPrint.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            return healResultPrint.ToString().TrimEnd();
        }
    }
}
