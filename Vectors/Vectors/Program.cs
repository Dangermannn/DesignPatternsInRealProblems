using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Adapters;
using Vectors.Interfaces;
using Vectors.Vectors;

namespace Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("2D VECTORS");
            Console.WriteLine("===========");
            Vector2D v1_2d = new Vector2D(3, 4);
            Vector2D v2_2d = new Vector2D(2, 2);
            Console.WriteLine("ABS: " + v1_2d.Abs());
            Console.WriteLine("CDOT: " + v1_2d.Cdot(v2_2d));

            Console.WriteLine();
            Console.WriteLine("n3D VECTORS");
            Console.WriteLine("===========");
            Vector3D v1_3d = new Vector3D(8, 4, 1);
            Vector3D v2_3d = new Vector3D(1, 2, 3);

            Console.WriteLine("ABS: " + v1_3d.Abs());
            Console.WriteLine("CDOT: " + v1_3d.Cdot(v2_3d));


            IVectorConverter ivc_2d = new Vector2DAdapter(new Vector2DPolarCoordinates(5, 60));
            IVector v3_2d = ivc_2d.GetVectorInCartesian();
            var components_2d = v3_2d.GetComponents();
            Console.WriteLine("CONVERTSION TO CARTESIAN");
            Console.WriteLine($"[{components_2d[0]}, {components_2d[1]}]");

            IVectorConverter ivc_3d = new Vector3DAdapter(new Vector3dSphericalCoordinate(5, 30, 60));
            IVector v3_3d = ivc_3d.GetVectorInCartesian();
            var components_3d = v3_3d.GetComponents();
            Console.WriteLine("CONVERTSION TO CARTESIAN");
            Console.WriteLine($"[{components_3d[0]}, {components_3d[1]}, {components_3d[2]}]");


            Console.ReadKey();
        }
    }
}
