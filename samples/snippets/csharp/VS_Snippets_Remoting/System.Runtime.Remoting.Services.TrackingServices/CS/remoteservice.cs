//<snippet10>
using System;

// Remote object.
public class RemoteService : MarshalByRefObject
{
    private DateTime startTime;

    public RemoteService()
    {
        // Notify the user that the constructor was invoked.
        Console.WriteLine("Constructor invoked.");
        startTime = DateTime.Now;
    }

    ~RemoteService()
    {
        // Notify the user that the finalizer was invoked.
        TimeSpan elapsedTime = 
            new TimeSpan(DateTime.Now.Ticks - startTime.Ticks);
        Console.WriteLine("Finalizer invoked after " + 
            elapsedTime.ToString() + " seconds.");
    }

    public void Hello(string name)
    {
        // Print a simple message.
        Console.WriteLine("Hello, " + name);
    }
}
//</snippet10>
