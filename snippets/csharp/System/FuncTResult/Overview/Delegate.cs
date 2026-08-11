// <Snippet1>
using System;
using System.IO;

delegate bool WriteMethod();

public class CustomDelegateExample
{
    public static void Run()
    {
        CustomDelegateOutputTarget output = new();
        WriteMethod methodCall = output.SendToFile;
        if (methodCall())
            Console.WriteLine("Success!");
        else
            Console.WriteLine("File write operation failed.");
    }
}

public class CustomDelegateOutputTarget
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
// </Snippet1>
