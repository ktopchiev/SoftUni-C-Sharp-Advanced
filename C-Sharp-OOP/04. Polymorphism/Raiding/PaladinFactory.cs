using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class PaladinFactory : Factory
    {
        private string name;

        public PaladinFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero GetHero()
        {
            return new Paladin(name);
        }
    }
}
