using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Interfaces;

namespace Vectors.Decorators
{
    public class VectorDecorator : IVector
    {
        protected IVector vector;

        public VectorDecorator() { }
        public VectorDecorator(IVector vec)
        {
            vector = vec;
        }
        public virtual double Abs()
        {
            return vector.Abs();
        }

        public virtual double Cdot(IVector vector)
        {
            return vector.Cdot(vector);
        }

        public virtual double[] GetAngles()
        {
            return vector.GetAngles();
        }

        public virtual double[] GetComponents()
        {
            return vector.GetComponents();
        }
    }
}
