//<Snippet1>
using System;
using System.Reflection;

public class CreateInstanceWorker : MarshalByRefObject
{
    public void PrintDomain()
    {
        Console.WriteLine("Object is executing in AppDomain \"{0}\"",
            AppDomain.CurrentDomain.FriendlyName);
    }
}

class CreateInstanceAndUnwrapSourceSnippet
{
    public static void Main()
    {
        // Create an ordinary instance in the current AppDomain
        CreateInstanceWorker localWorker = new CreateInstanceWorker();
        localWorker.PrintDomain();

        // Create a new application domain, create an instance
        // of Worker in the application domain, and execute code
        // there.
        AppDomain ad = AppDomain.CreateDomain("New domain");
        CreateInstanceWorker remoteWorker = (CreateInstanceWorker) ad.CreateInstanceAndUnwrap(
            typeof(CreateInstanceWorker).Assembly.FullName,
            "Worker");
        remoteWorker.PrintDomain();
    }
}

/* This code produces output similar to the following:

Object is executing in AppDomain "source.exe"
Object is executing in AppDomain "New domain"
 */
//</Snippet1>
