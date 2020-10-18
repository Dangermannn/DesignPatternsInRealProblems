using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Vectors;

namespace Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector3D v = new Vector3D(1, 2, 3);
            Vector3D y = new Vector3D(1, 2, 3);

            Console.WriteLine(v.Cdot(v));
            Console.ReadKey();
        }
    }
}
