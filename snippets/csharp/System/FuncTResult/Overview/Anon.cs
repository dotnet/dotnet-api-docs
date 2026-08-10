// <Snippet3>
using System;
using System.IO;

public class Anonymous
{
    public static void Main()
    {
        OutputTarget output = new();
        Func<bool> methodCall = delegate () { return output.SendToFile(); };
        if (methodCall())
            Console.WriteLine("Success!");
        else
            Console.WriteLine("File write operation failed.");
    }
}

public class OutputTarget
{
    public bool SendToFile()
    {
        try
        {
            string fn = Path.GetTempFileName();
            using StreamWriter sw = new(fn);
            sw.WriteLine("Hello, World!");
            return true;
        }
        catch
        {
            return false;
        }
    }
}
// </Snippet3>
