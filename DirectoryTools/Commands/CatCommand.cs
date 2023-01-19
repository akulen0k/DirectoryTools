

namespace DirectoryTools.Commands;

public class CatCommand : ICommandDir
{
    public void ExecuteCommand(ref string path, string[] args)
    {
        if (args.Length < 1)
            throw new Exception("Cat must have at least one argument");

        Console.WriteLine();
        if (File.Exists(path + "/" + args[0]) || File.Exists(args[0]))
        {
            string filePath = File.Exists(path + "/" + args[0]) ? path + "/" + args[0] : args[0];
            using (var sr = new StreamReader(filePath))
            {
                for (int i = 0; i < 20 && !sr.EndOfStream; ++i)
                {
                    string s = sr.ReadLine();
                    Console.WriteLine(s);
                }
            }
        }
        else
        {
            Console.WriteLine($"File wasn't found");
        }
        Console.WriteLine();
    }
    
    public void _getHelpMsg()
    {
        Console.WriteLine("This command prints selected file into cmd.");
    }
}