namespace DirectoryTools.Commands;


public interface ICommandDir
{
    public void ExecuteCommand(ref string path, string[] args);
    public void _getHelpMsg();
}