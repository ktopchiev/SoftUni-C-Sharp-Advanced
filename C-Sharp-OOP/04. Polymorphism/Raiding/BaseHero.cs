using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        
        private string name;
        private int power;

        public BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public abstract string HeroType
        {
            get;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length > 0)
                {
                    name = value;
                }
            }
        }
        public int Power
        {
            get => power;
            private set
            {
                if (value >= 0)
                {
                    power = value;
                }
            }
        }

        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name}";
        }
    }
}
