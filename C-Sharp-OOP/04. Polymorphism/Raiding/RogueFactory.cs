using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class RogueFactory : Factory
    {
        private string name;

        public RogueFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero GetHero()
        {
            return new Rogue(name);
        }
    }
}
