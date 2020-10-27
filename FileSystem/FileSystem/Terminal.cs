using FileSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class Terminal : ITerminal
    {
        private TreeNode Files;

        public Terminal(TreeNode files)
        {
            Files = files;
        }

        public void Run()
        {
            for(; ; )
            {
                var command = Console.ReadLine();
                Execute(command);
            }
        }

        public void Execute(string command)
        {
            var com = command.Contains(TerminalCommands.More) ? TerminalCommands.More : command;
            var sep_com = command.Split(' ');
           // Console.WriteLine($"1: {sep_com[0]} 2:{sep_com[1]}");
            switch(sep_com[0])
            {
                case TerminalCommands.Tree:
                    ShowTree();
                    break;
                case TerminalCommands.Ls:
                    ShowFiles();
                    break;
                case TerminalCommands.More:
                    if(sep_com.Length < 2)
                    {
                        Console.WriteLine("Incorrect command");
                        break;
                    }
                    ShowMore(sep_com[1]);
                    break;
                case TerminalCommands.Clear:
                    Console.Clear();
                    break;
                case TerminalCommands.Exit:
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("There's no such a command!");
                    break;
            }
        }

        private void ShowTree()
        {
            Files.DrawTree(1);
        }

        private void ShowFiles()
        {
            Files.ShowNode();
        }

        private void ShowMore(string fileName)
        {
            var file = Files.GetFile(fileName);
            Console.WriteLine(file);
        }
    }
}
