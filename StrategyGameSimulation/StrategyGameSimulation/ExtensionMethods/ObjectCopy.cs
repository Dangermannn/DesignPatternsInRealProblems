using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace StrategyGameSimulation.ExtensionMethods
{
    public static class ObjectCopy
    {
        public static T DeepCopy<T>(this T obj)
        {
            using(MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, obj);
                stream.Position = 0;
                return (T)bf.Deserialize(stream);
            }
        }
    }
}
