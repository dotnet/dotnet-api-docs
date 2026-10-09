// <Snippet1>
using System;
using System.IO;
using System.Text.RegularExpressions;

public class WordCount
{
    private string filename = string.Empty;
    private int nWords = 0;
    private string pattern = @"\b\w+\b";

    public WordCount(string filename)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException("The file does not exist.");

        this.filename = filename;
        string txt = string.Empty;
        using (StreamReader sr = new(filename))
        {
            txt = sr.ReadToEnd();
        }
        nWords = Regex.Matches(txt, pattern).Count;
    }

    public string FullName => filename;

    public string Name => Path.GetFileName(filename);

    public int Count => nWords;
}
// </Snippet1>

public class Example8
{
    public static void Main()
    {
        WordCount wc = new(@"C:\users\ronpet\documents\Fr_Mike_Mass.txt");
        Console.WriteLine($"File {wc.Name} ({wc.FullName}) has {wc.Count} words");
    }
}
