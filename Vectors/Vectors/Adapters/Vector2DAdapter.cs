using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Interfaces;
using Vectors.Vectors;

namespace Vectors.Adapters
{
    public class Vector2DAdapter : Vector2D, IVectorConverter
    {
        private Vector2DPolarCoordinates _vector2DPolarCoordinates;
        public Vector2DAdapter(Vector2DPolarCoordinates v2)
        {
            _vector2DPolarCoordinates = v2;
        }

        public double[] ConvertCoordinatesToCartesionArray()
        {
            return new double[] { _vector2DPolarCoordinates.R * Math.Cos(_vector2DPolarCoordinates.Phi),
                _vector2DPolarCoordinates.R * Math.Sin(_vector2DPolarCoordinates.Phi)};
        }

        public IVector GetVectorInCartesian()
        {
            var cartesianCoordinates = ConvertCoordinatesToCartesionArray();
            return new Vector2D(cartesianCoordinates[0], cartesianCoordinates[1]);
        }
    }
}
