using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int _comfort = 1;
        private const decimal _price = 5;

        public Ornament()
            : base(_comfort, _price)
        {
        }
    }
}
