namespace DirectoryTools.Commands;

public class HelpCommand : ICommandDir
{
    public void ExecuteCommand(ref string path, string[] args)
    {
        Console.WriteLine();
        Console.WriteLine(  "- Cat\n"
                          + "- cd\n"
                          + "- ps\n"
                          + "- touch\n"
                          + "- help\n"
                          + "- show"
        );
        Console.WriteLine();
    }
    
    public void _getHelpMsg()
    {
        Console.WriteLine("This command prints all available commands.");
    }
}