using FileSystem.Interfaces;
using FileSystem.Manager;
using FileSystem.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileSystem
{
    public class Folder : TreeNode
    {
        public List<TreeNode> Children;

        public Folder(string fullPath) : base(fullPath)
        {
            Children = new List<TreeNode>();
        }

        public override void DrawTree(int depth)
        {
            Console.WriteLine(new String(' ', depth) + "\\" + FullPath);
            foreach (var child in Children)
                child.DrawTree(depth + 2);
        }

        public override string GetFile(string fileName)
        {
            string fileData = "";
            foreach(var child in Children)
            {
                fileData = child.GetFile(fileName);
                // if file is found
                if (!String.IsNullOrEmpty(fileData))
                    break;
            }
            return fileData ?? "Cannot find such a file";
        }

        public override void ShowNode()
        {
            foreach (var child in Children)
            {
                 child.ShowNode();
                 Console.Write("\t");
            }
                
        }

        public void AddFile(TreeNode file)
        {
            FilenameValidatorProxy validator = new FilenameValidatorProxy(file);
            if (!validator.ValidateFilename(file.FullPath))
                throw new Exception("Incorrent filename");
            Children.Add(file);
        }
    }
}
