using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors.Vectors
{
    public class Vector2DPolarCoordinates
    {
        public double R;
        public double Phi;

        public Vector2DPolarCoordinates(double r, double phi)
        {
            R = r;
            Phi = phi;
        }
    }
}
