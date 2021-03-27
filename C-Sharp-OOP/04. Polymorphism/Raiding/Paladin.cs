using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private readonly string heroType;

        public Paladin(string name, int power = 100)
            : base(name, power)
        {
            heroType = "Paladin";
        }

        public override string HeroType
        {
            get { return HeroType; }
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {Power}";
        }
    }
}
