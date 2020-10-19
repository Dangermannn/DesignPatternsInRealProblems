using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors.Vectors
{
    public class Vector3dSphericalCoordinate : Vector2DPolarCoordinates
    {
        public double Theta;
        public Vector3dSphericalCoordinate(double r, double phi, double theta) : base(r, phi)
        {
            Theta = theta;
        }
    }
}
