namespace DirectoryTools.Commands;

public class CdCommand : ICommandDir
{
    public void ExecuteCommand(ref string path, string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("cd must have at least one argument");
            return;
        }

        Console.WriteLine();
        if (Directory.Exists(path + "/" + args[0]))
        {
            path += "/" + args[0];
            DirectoryInfo di = new DirectoryInfo(path);
            path = di.FullName;
            Console.WriteLine($"New path {path}");
        }
        else if (Directory.Exists(args[0]))
        {
            path = args[0];
            Console.WriteLine($"New path {path}");
        }
        else
        {
            Console.WriteLine("This directory does not exist");
        }
        Console.WriteLine();
    }

    public void _getHelpMsg()
    {
        Console.WriteLine("Use this command to travel through directories.");
    }
}