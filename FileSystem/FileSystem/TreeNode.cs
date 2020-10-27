using FileSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileSystem
{
    // Leaf 
    public abstract class TreeNode : ITreeNode
    {
        public string FullPath { get; set; }

        public TreeNode() { }
        public TreeNode(string path)
        { 
            FullPath = path;
        }
        public virtual void DrawTree(int depth)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(new String('-', depth));
            sb.Append(FullPath);
            Console.WriteLine($"{sb.ToString()}");
        }

        public virtual void ShowNode()
        {
            Console.Write(FullPath);
        }

        public virtual string GetFile(string fileName)
        {
            if (FullPath == fileName)
                return "";
            return null;
        }

        public string GetPath() => FullPath;

    }
}