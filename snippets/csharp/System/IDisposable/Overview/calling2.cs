// <Snippet2>
using System;
using System.IO;
using System.Text.RegularExpressions;

public class WordCount2
{
    private string filename = string.Empty;
    private int nWords = 0;
    private string pattern = @"\b\w+\b";

    public WordCount2(string filename)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException("The file does not exist.");

        this.filename = filename;
        string txt = string.Empty;
        StreamReader? sr = null;
        try
        {
            sr = new(filename);
            txt = sr.ReadToEnd();
        }
        finally
        {
            if (sr != null) sr.Dispose();
        }
        nWords = Regex.Matches(txt, pattern).Count;
    }

    public string FullName => filename;

    public string Name => Path.GetFileName(filename);

    public int Count => nWords;
}
// </Snippet2>

public class Example
{
    public static void Main()
    {
        WordCount2 wc = new(@"C:\users\ronpet\documents\Fr_Mike_Mass.txt");
        Console.WriteLine($"File {wc.Name} ({wc.FullName}) has {wc.Count} words");
    }
}
