// <Snippet3>
using System;
using System.IO;

public class AnonymousMethodExample
{
    public static void Run()
    {
        AnonymousOutputTarget output = new();
        Func<bool> methodCall = delegate () { return output.SendToFile(); };
        if (methodCall())
            Console.WriteLine("Success!");
        else
            Console.WriteLine("File write operation failed.");
    }
}

public class AnonymousOutputTarget
{
    public bool SendToFile()
    {
        try
        {
            string fn = Path.GetTempFileName();
            StreamWriter sw = new(fn);
            sw.WriteLine("Hello, World!");
            sw.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
// </Snippet3>
