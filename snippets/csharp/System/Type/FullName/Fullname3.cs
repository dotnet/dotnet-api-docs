// <Snippet3>
using System;


public class FullName3Example
{
    public static void Run()
    {
        Type t = typeof(Nullable<>);
        Console.WriteLine(t.FullName);
        if (t.IsGenericType)
        {
            Console.Write("   Generic Type Parameters: ");
            Type[] gtArgs = t.GetGenericArguments();
            for (int ctr = 0; ctr < gtArgs.Length; ctr++)
            {
                Console.WriteLine(gtArgs[ctr].FullName ??
                                  "(unassigned) " + gtArgs[ctr]);
            }
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//       System.Nullable`1
//          Generic Type Parameters: (unassigned) T
// </Snippet3>
