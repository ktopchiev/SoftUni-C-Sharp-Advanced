using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        private readonly string heroType;

        public Druid(string name, int power = 80)
            : base(name, power)
        {
            heroType = "Druid";
        }

        public override string HeroType
        {
            get { return heroType; }
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {Power}";
        }
    }
}
