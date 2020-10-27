using FileSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Manager
{
    public class File : TreeNode
    {
        public byte[] FileContent;
        public File(byte[] fileContent, string fullPath) : base(fullPath)
        {
            FileContent = fileContent;
        }

        public override void DrawTree(int depth)
        {
            Console.WriteLine(new String(' ', depth) + "|" + base.FullPath);
        }

        public override string GetFile(string fileName)
        {
            //Console.WriteLine($"BASE: {base.FullPath}, LF: {fileName}");
            if (base.FullPath == fileName)
                return Encoding.UTF8.GetString(FileContent);
            return null;
        }
    }
}
