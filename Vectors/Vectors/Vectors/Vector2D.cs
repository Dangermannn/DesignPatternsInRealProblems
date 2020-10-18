using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Interfaces;

namespace Vectors.Vectors
{
    public class Vector2D : IVector
    {
        private double x;
        private double y;

        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double Abs() => Math.Sqrt(x * x + y * y);
        public double Cdot(IVector vector)
        {
            var comp = vector.GetComponents();
            return x * y + comp[0] * comp[1];
        }

        public double[] GetAngles()
        {
            var r = Math.Sqrt(x * x + y * y);
            var phi = Math.Atan(y / x);

            return new double[] { r * Math.Cos(phi), r * Math.Sin(phi) };
        }

        public double[] GetComponents() => new double[] { x, y };
    }
}
