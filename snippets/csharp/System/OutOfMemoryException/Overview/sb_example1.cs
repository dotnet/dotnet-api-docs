// <Snippet1>
using System;
using System.Text;

public class OutOfMemoryExceptionExample4
{
    public static void Run()
    {
        StringBuilder sb = new(15, 15);
        sb.Append("Substring #1 ");
        try
        {
            sb.Insert(0, "Substring #2 ", 1);
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine($"Out of Memory: {e.Message}");
        }
    }
}
// The example displays the following output:
//    Out of Memory: Insufficient memory to continue the execution of the program.
// </Snippet1>
