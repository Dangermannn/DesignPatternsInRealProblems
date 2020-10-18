using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors.Vectors;

namespace Vectors.Interfaces
{
    public interface IVector
    {
        double Abs();
        double[] GetComponents();
        double[] GetAngles();
        double Cdot(IVector vector);
    }
}
