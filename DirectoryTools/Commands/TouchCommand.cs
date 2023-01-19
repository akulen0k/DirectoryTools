namespace DirectoryTools.Commands;

public class TouchCommand : ICommandDir
{
    public void ExecuteCommand(ref string path, string[] args)
    {
        if (!File.Exists(path + "/" + args[0]))
        {
            File.Create(path + "/" + args[0]).Close();
            Console.WriteLine($"Successfully created file {args[0]}");
        }
        else
        {
            Console.WriteLine($"File {args[0]} is already exsists");
        }
    }

    public void _getHelpMsg()
    {
        Console.WriteLine("Create file in current directory");
    }
}