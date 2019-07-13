using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        public double SurfaceArea()
        {
            return 2 * length * width
                + 2 * length * height
                + 2 * width * height;

        }
      

        public double LateralSurfaceArea()
        {
            return 2 * length * height
                 + 2 * width * height;
        }

        public double Volume()
        {
            return length * height * width;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                itIsValue(value, nameof(this.Length));

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                itIsValue(value,nameof(this.Width));
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                itIsValue(value,nameof(this.Height));
                this.height = value;
            }
        }

        private void itIsValue(double value, string name)
        {
            if (value <= 0)
            {
               throw new ArgumentException($"{name} cannot be zero or negative.");
            }
        }

    }
}
