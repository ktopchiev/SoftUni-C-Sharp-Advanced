﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get => radius; private set => radius = value; }

        public override double CalculateArea()
        {
            return (Math.PI * (radius * radius));
        }

        public override double CalculatePerimeter()
        {
            return (2 * Math.PI * radius);
        }

        public override string Draw()
        {
            return "Circle";
        }
    }
}
