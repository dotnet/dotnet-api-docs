// <Snippet2>
using System;
using System.IO;

public class FuncDelegateExample
{
    public static void Run()
    {
        FuncDelegateOutputTarget output = new();
        Func<bool> methodCall = output.SendToFile;
        if (methodCall())
            Console.WriteLine("Success!");
        else
            Console.WriteLine("File write operation failed.");
    }
}

public class FuncDelegateOutputTarget
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
// </Snippet2>
