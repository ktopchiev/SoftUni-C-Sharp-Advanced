using System;

namespace ClassBoxData
{
    public class Box
    {   
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        { 
            get => length; 
            
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                length = value;
            }
        }

        public double Width 
        { 
            get => width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                width = value;
            }
        }

        public double Height
        {
            get => height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                height = value;
            }
        }

        public double GetVolume()
        {
            return length * width * height;
        }

        public double GetLateralSurfaceArea()
        {
            
            return 2 * length * height + 2 * width * height;
        }

        public double GetSurfaceArea()
        { 
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }
    }
}
