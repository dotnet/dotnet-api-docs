// <Snippet1>
using System.Collections.Generic;

public class UseBeforeAssignExample
{
    public static void Main(string[] args)
    {
        int value = int.Parse(args[0]);
        List<string> names;
        if (value > 0)
            names = [];

        //names.Add("Major Major Major");
    }
}
// Compilation displays a warning like the following:
//    Example1.cs(10) : warning BC42104: Variable //names// is used before it
//    has been assigned a value. A null reference exception could result
//    at runtime.
//
//          names.Add("Major Major Major")
//          ~~~~~
// The example displays output like the following output:
//    Unhandled Exception: System.NullReferenceException: Object reference
//    not set to an instance of an object.
//       at Example.Main()
// </Snippet1>
