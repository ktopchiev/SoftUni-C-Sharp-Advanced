﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        public Backpack(int capacity = 100)
            : base(capacity)
        {
        }
    }
}
