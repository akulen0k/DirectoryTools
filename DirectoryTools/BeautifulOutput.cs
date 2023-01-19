using System.Text;

namespace DirectoryTools;

public static class BeautifulOutput
{
    public static readonly string[] Nulls = { "", "-", " ", "null", "nan" };
    public static readonly string[] Separators = { ",", "\'", "\"", "[", "]" };
    public static readonly char[] ArrOrStr = { '\'', '\"', '[', ']' };
    public static readonly char[] SeparatorsCsv = {','};
    
    
        // converts string to csv format
    private static string ConvString(string s) 
    {
        if (s is null || Nulls.Contains(s)) return "null";
        if (Separators.Any(x => s.Contains(x)) 
            && (s[0] != '\'' && s[0] != '\"' && s[s.Length - 1] != '\'' && s[s.Length - 1] != '\"'))
                return "\"" + s + '\"';
        return s;
    }

    // converts array to csv format
    private static string ConvStrArray(string[] arr)
    {
        if (arr is null || arr.Length == 0) return "null";
        StringBuilder sr = new StringBuilder("");
        sr.Append("[");
        for (int i = 0; i < arr.Length; ++i)
        {
            sr.Append(BeautifulOutput.ConvString(arr[i]));
            if (i + 1 != arr.Length)
                sr.Append(", ");
        }
        sr.Append("]");
        return sr.ToString();
    }

    // parses string from int? or null
    private static string ConvInt(int? v)
    {
        if (v is null) return "null";
        return Convert.ToString(v);
    }
    
    // returns the array of maximum length of strings in each column
    private static int[] GetMaxLength(string[][] arr)
    {
        int[] ans = new int[arr[0].Length];
        for (int i = 0; i < ans.Length; ++i) ans[i] = 0;
        
        for (int i = 0; i < arr.GetLength(0); ++i)
        {
            for (int j = 0; j < arr[i].Length; ++j) ans[j] = Math.Max(ans[j], ConvString(arr[i][j]).Length);
        }

        return ans;
    }

    // creates csv format strings from array of strings
    public static string[] BeautifulStrings(string[][] arr)
    {
        if (arr.GetLength(0) == 0) return new string[] { "" };
        
        for (int i = 0; i < arr.GetLength(0); ++i)
            if (arr[i].Length != arr[0].Length)
                    throw new Exception("All rows must have equal size.");
        
        int[] spaces = GetMaxLength(arr);
        string[] ans = new string[arr.GetLength(0)];
        const int EXTRA_SPACES = 3; // spaces between column and comma
        
        for (int i = 0; i < arr.GetLength(0); ++i)
        {
            var finalSt = new StringBuilder("");
            for (int j = 0; j < arr[i].Length; ++j)
            {
                // spaces before the word and after to center it
                int before = 0, after = 0;
                before = (spaces[j] - BeautifulOutput.ConvString(arr[i][j]).Length) / 2;
                after = spaces[j] - before - BeautifulOutput.ConvString(arr[i][j]).Length;
                
                if (j != 0) before += EXTRA_SPACES;
                if (j + 1 != arr[i].Length) after += EXTRA_SPACES;

                var tmp = new StringBuilder("");
                for (int k = 0; k < before; ++k) tmp.Append(" ");
                tmp.Append(BeautifulOutput.ConvString(arr[i][j]));
                for (int k = 0; k < after; ++k) tmp.Append(" ");
                if (j + 1 != arr[i].Length) tmp.Append(" ");

                finalSt.Append(tmp.ToString());
            }

            ans[i] = finalSt.ToString();
        }

        return ans;
    }

    // prints array of strings in Console, truncating it if needed
    public static void BeautifulPrint(string[] arr, int lines = 8)
    {
        if (arr.Length == 0) return;
        for (int i = 0; i < 50; ++i) Console.Write('-');
        Console.WriteLine();
        for (int i = 0; i < arr.Length && i <= lines; ++i)
        {
            if (i != lines)
                Console.WriteLine(arr[i]);
            else Console.WriteLine("...");
        }
        for (int i = 0; i < 50; ++i) Console.Write('-');
        Console.WriteLine();
    }
    
}