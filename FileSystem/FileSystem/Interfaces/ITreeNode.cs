using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Interfaces
{
    // Component
    public interface ITreeNode
    {
        void DrawTree(int depth);
        void ShowNode();
        string GetFile(string fileName);
    }
}
