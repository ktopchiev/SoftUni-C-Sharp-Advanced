using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class WarriorFactory : Factory
    {
        private string name;

        public WarriorFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero GetHero()
        {
            return new Warrior(name);
        }
    }
}
