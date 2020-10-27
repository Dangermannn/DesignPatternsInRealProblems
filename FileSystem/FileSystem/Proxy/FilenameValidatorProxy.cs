using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Proxy
{
    public class FilenameValidatorProxy
    {
        private readonly TreeNode _node;
        
        public FilenameValidatorProxy(TreeNode node)
        {
            _node = node;
        }

        public bool ValidateFilename(string filename) =>  filename.All(c => Char.IsLetterOrDigit(c) || c.Equals('.'));
    }
}
