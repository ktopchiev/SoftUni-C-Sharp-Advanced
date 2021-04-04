using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int _weight = 5;

        public FirePotion()
            : base(_weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.UseItem(this);
        }
    }
}
