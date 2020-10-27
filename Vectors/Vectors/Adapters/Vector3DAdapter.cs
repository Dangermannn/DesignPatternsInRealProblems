using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Interfaces;
using Vectors.Vectors;

namespace Vectors.Adapters
{
    public class Vector3DAdapter : Vector3D, IVectorConverter
    {
        private Vector3dSphericalCoordinate _vector3DSphericalCoordinates;
        public Vector3DAdapter(Vector3dSphericalCoordinate v3)
        {
            _vector3DSphericalCoordinates = v3;
        }

        private double[] ConvertCoordinatesToCartesianArray()
        {
            return new double[] {
                _vector3DSphericalCoordinates.R * Math.Cos(_vector3DSphericalCoordinates.Theta) * Math.Sin(_vector3DSphericalCoordinates.Phi),
                _vector3DSphericalCoordinates.R * Math.Sin(_vector3DSphericalCoordinates.Theta) * Math.Sin(_vector3DSphericalCoordinates.Phi),
                _vector3DSphericalCoordinates.R * Math.Cos(_vector3DSphericalCoordinates.Phi)
            };
        }

        public IVector GetVectorInCartesian()
        {
            var coordinatesInCartesian = ConvertCoordinatesToCartesianArray();
            return new Vector3D(coordinatesInCartesian[0], coordinatesInCartesian[1], coordinatesInCartesian[2]);
        }
    }
}
