namespace DirectoryTools.Commands;

public static class ArgParser
{
    public static (string, string[]) parseStr(string s)
    {
        var args = s.Split(" ");
        for (int i = 0; i < args.Length; ++i)
        {
            args[i] = args[i].Trim();
        }

        string command = "";
        string[] arg = new string[Math.Max(0, args.Length - 1)];
        if (args.Length > 0)
        {
            command = args[0];
        }

        for (int i = 1; i < args.Length; ++i)
        {
            arg[i - 1] = args[i];
        }

        return (command, arg);
    }
}