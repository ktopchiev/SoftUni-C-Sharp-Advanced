using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class DruidFactory : Factory
    {
        private string name;

        public DruidFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero GetHero()
        {
            return new Druid(name);
        }
    }
}
