using System.ComponentModel.Design;

namespace DirectoryTools.Commands;

public class ShowCommand : ICommandDir
{
    private void dfs(string path, int curD = 0, int maxDepth = 2, int spaces = 3)
    {
        string space = "";
        for (int i = 0; i < spaces * curD; ++i) space += " "; 
        foreach (var v in Directory.GetDirectories(path).ToList())
        {
            Console.WriteLine(space + new DirectoryInfo(v).Name);
            if (curD != maxDepth)
                dfs(v, curD + 1, maxDepth, spaces);
        }
        foreach (var v in Directory.GetFiles(path).ToList())
        {
            Console.WriteLine(space + new FileInfo(v).Name);
        }
    }
    public void ExecuteCommand(ref string path, string[] args)
    {
        if (Directory.Exists(path) || (args.Length > 0 && Directory.Exists(args[0])))
        {
            string dPath = path;
            if (args.Length > 0 && Directory.Exists(args[0]))
            {
                dPath = args[0];
            }
            Console.WriteLine();
            dfs(dPath);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid directory");
        }
    }

    public void _getHelpMsg()
    {
        Console.WriteLine("Show the structed of the directory");
    }
}