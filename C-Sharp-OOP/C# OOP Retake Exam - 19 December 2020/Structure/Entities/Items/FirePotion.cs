using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int _weight = 5;
        private const int Damage = 20;

        public FirePotion()
            : base(_weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            if (character.Health > Damage)
            {
                character.Health -= Damage;
            }
            else
            {
                character.IsAlive = false;
                character.Health = 0;
            }
        }
    }
}
