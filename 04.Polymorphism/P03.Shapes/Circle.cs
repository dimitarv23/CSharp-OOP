using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius cannot be 0 or negative.");
                }

                radius = value;
            }
        }

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
