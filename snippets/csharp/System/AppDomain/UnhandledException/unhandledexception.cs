// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.UnhandledException += new(MyHandler);

        try
        {
            throw new Exception("1");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Catch clause caught : {e.Message} \n");
        }

        throw new Exception("2");
    }

    static void MyHandler(object sender, UnhandledExceptionEventArgs args)
    {
        Exception e = (Exception)args.ExceptionObject;
        Console.WriteLine("MyHandler caught : " + e.Message);
        Console.WriteLine($"Runtime terminating: {args.IsTerminating}");
    }
}
// The example displays the following output:
//       Catch clause caught : 1
//
//       MyHandler caught : 2
//       Runtime terminating: True
//
//       Unhandled Exception: System.Exception: 2
//          at Example.Main()
// </Snippet1>
