using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private readonly string heroType;

        public Warrior(string name, int power = 100)
            : base(name, power)
        {
            heroType = GetType().Name;
        }

        public override string HeroType
        {
            get { return heroType; }
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {Power} damage";
        }
    }
}
