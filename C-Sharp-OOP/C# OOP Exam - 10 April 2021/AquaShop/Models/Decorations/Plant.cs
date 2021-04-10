using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int _comfort = 5;
        private const decimal _price = 10;

        public Plant()
            : base(_comfort, _price)
        {
        }
    }
}
