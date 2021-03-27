using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private readonly string heroType;

        public Rogue(string name, int power = 80)
            : base(name, power)
        {
            heroType = "Rogue";
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
