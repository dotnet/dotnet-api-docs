using System;

public class Array1Example
{
    public static void Main()
    {
        // <Snippet8>
        string[] values = [ "one", null, "two" ];
        for (int ctr = 0; ctr <= values.GetUpperBound(0); ctr++)
            Console.Write("{0}{1}", values[ctr].Trim(),
                          ctr == values.GetUpperBound(0) ? "" : ", ");
        Console.WriteLine();

        // The example displays the following output:
        //    Unhandled Exception:
        //       System.NullReferenceException: Object reference not set to an instance of an object.
        // </Snippet8>
    }
}
