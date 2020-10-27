using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Decorators;
using Vectors.Interfaces;

namespace Vectors.Vectors
{
    public class Vector3D : VectorDecorator, IVector3D
    {
        private double z;

        public Vector3D() { }
        public Vector3D(double x, double y, double z) : base(new Vector2D(x, y))
        {
            this.z = z;
        }

        public override double Abs()
        {
            var baseVec2d = base.GetComponents();
            return Math.Sqrt(baseVec2d[0] * baseVec2d[0] + baseVec2d[1] * baseVec2d[1] + z * z);
        }

        public override double Cdot(IVector vector)
        {
            var baseVec2d = base.GetComponents();
            var vecToScal = vector.GetComponents();
            return baseVec2d[0] * vecToScal[0] + baseVec2d[1] * vecToScal[1] + vecToScal[2] * z;
        }

        public override double[] GetAngles()
        {
            var baseVec2d = base.GetComponents();
            var r = Math.Sqrt(baseVec2d[0] * baseVec2d[0] + baseVec2d[1] * baseVec2d[1] + z * z);
            // arctan(y/x)
            var phi = Math.Atan(baseVec2d[1] / baseVec2d[0]);
            // arctan(sqrt(x^2+y^2)/z)
            var theta = Math.Atan(Math.Sqrt((baseVec2d[0] * baseVec2d[0] + baseVec2d[1] * baseVec2d[1]) / z));

            return new double[] { r, theta, phi };
        }

        public override double[] GetComponents()
        {
            var baseVec2d = base.GetComponents();

            return new double[] { baseVec2d[0], baseVec2d[1], z };
        }

        public double[] VectorProduct(IVector vec3d)
        {
            var b = vec3d.GetComponents();
            var a = base.GetComponents();
            return new double[] { a[1] * b[2] - z * b[1], z * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0] };
        }
    }
}
