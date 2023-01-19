using DirectoryTools.Commands;

namespace DirectoryTools;

public class DirectoryTools
{
    private string _path;

    private Dictionary<string, ICommandDir> _allCommands =
        new Dictionary<string, ICommandDir>()
        {
            {"Cat", new CatCommand()},
            {"cd", new CdCommand()},
            {"ps", new PsCommand()},
            {"touch", new TouchCommand()},
            {"help", new HelpCommand()},
            {"show", new ShowCommand()}
        };
    
    public DirectoryTools()
    {
        _path = Directory.GetCurrentDirectory();
    }

    public void StartWorking()
    {
        while (true)
        {
            var (command, args) = ArgParser.parseStr(Console.ReadLine());
            if (_allCommands.ContainsKey(command))
            {
                if (args.ToList().Contains("--help"))
                {
                    _allCommands[command]._getHelpMsg();
                }
                else
                {
                    _allCommands[command].ExecuteCommand(ref _path, args);
                }
            }
            else
            {
                Console.WriteLine($"Comand {command} was not found.");
            }
        }
    }
}