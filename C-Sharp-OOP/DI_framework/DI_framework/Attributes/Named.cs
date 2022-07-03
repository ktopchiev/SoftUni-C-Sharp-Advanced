using System;
using System.Collections.Generic;
using System.Text;

namespace DI_framework.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field)]
    public class Named : Attribute
    {
        public Named(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
