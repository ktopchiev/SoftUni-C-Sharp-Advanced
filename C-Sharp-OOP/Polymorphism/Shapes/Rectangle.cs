using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get => height; private set => height = value; }

        public double Width { get => width; private set => width = value; }


        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return (height * 2) + (width * 2);
        }

        public override string Draw()
        {
            return "Rectangle";
        }
    }
}
