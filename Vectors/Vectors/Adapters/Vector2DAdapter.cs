using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Interfaces;
using Vectors.Vectors;

namespace Vectors.Adapters
{
    public class Vector2DAdapter : Vector2D, IVector
    {
        public Vector2DAdapter(double x, double y) : base(x, y)
        {
        }
    }
}
