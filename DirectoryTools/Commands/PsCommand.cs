namespace DirectoryTools.Commands;

public class PsCommand : ICommandDir
{
    public void ExecuteCommand(ref string path, string[] args)
    {
        Console.WriteLine();
        var allList = new List<string[]>();
        foreach (var v in Directory.GetDirectories(path).ToList())
        {
            allList.Add(new []{"<DIR>", new DirectoryInfo(v).Name, Directory.GetCreationTime(v).ToString()});
        }
        foreach (var v in Directory.GetFiles(path).ToList())
        {
            allList.Add(new []{"<FILE>", new FileInfo(v).Name, File.GetCreationTime(v).ToString()});
        }

        var bf = BeautifulOutput.BeautifulStrings(allList.ToArray());
        foreach (var v in bf)
        {
            Console.WriteLine(v);
        }
        Console.WriteLine();
    }
    
    public void _getHelpMsg()
    {
        Console.WriteLine("This command prints selected file into cmd.");
    }
}