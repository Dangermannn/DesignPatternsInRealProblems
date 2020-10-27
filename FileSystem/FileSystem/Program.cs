using FileSystem.Interfaces;
using FileSystem.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            // Commands: tree, ls, more filename
            TreeNode f1 = new File(Encoding.ASCII.GetBytes("content file 1"), "test1");
            TreeNode f2 = new File(Encoding.ASCII.GetBytes("content file 2"), "test2");
            TreeNode f3 = new File(Encoding.ASCII.GetBytes("content file 3"), "test2");

            Folder n = new Folder("LOS");
            Folder n2 = new Folder("FOL2");
            Folder n3 = new Folder("MAIN1");
            try
            {
                n.AddFile(f1);
                n.AddFile(f2);
                n.AddFile(f3);

                n2.AddFile(f1);
                n2.AddFile(f2);
                n2.AddFile(f3);

                n3.AddFile(n);
                n3.AddFile(n2);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }


            // Adding file with wrong name
            try
            {
                TreeNode f4 = new File(Encoding.ASCII.GetBytes("wrong file name"), "t;;;");
                n.AddFile(f4);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }

            Terminal t = new Terminal(n3);
            t.Run();
            //Console.ReadKey();
        }
    }
}
