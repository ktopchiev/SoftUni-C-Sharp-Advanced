using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int _weight = 5;
        private const int HealPoints = 20;

        public HealthPotion()
            : base(_weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += HealPoints;
        }
    }
}
