using System;

public class ObjectReferenceEqualsExample1
{
    public static void Run()
    {
        // <Snippet1>
        int int1 = 3;
        Console.WriteLine(object.ReferenceEquals(int1, int1));
        Console.WriteLine(int1.GetType().IsValueType);

        // The example displays the following output:
        //       False
        //       True
        // </Snippet1>
    }
}
