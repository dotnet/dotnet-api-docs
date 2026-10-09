//<Snippet1>
using System;

public class AppException : Exception
{
    public AppException(string message) : base(message)
    { }

    public AppException(string message, Exception inner) : base(message, inner) { }
}

public class Example
{
    public static void Main()
    {
        Example ex = new();

        try
        {
            ex.CatchInner();
        }
        catch (AppException e)
        {
            Console.WriteLine("In catch block of Main method.");
            Console.WriteLine($"Caught: {e.Message}");
            if (e.InnerException != null)
                Console.WriteLine($"Inner exception: {e.InnerException}");
        }
    }

    public void ThrowInner() => throw new AppException("Exception in ThrowInner method.");

    public void CatchInner()
    {
        try
        {
            this.ThrowInner();
        }
        catch (AppException e)
        {
            throw new AppException("Error in CatchInner caused by calling the ThrowInner method.", e);
        }
    }
}
// The example displays the following output:
//    In catch block of Main method.
//    Caught: Error in CatchInner caused by calling the ThrowInner method.
//    Inner exception: AppException: Exception in ThrowInner method.
//       at Example.ThrowInner()
//       at Example.CatchInner()
// </Snippet1>
