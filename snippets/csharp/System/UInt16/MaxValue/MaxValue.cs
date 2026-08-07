using System;

public class Class1
{
    public static void Main()
    {
        // <Snippet1>
        int integerValue = 1216;
        ushort uIntegerValue;

        if (integerValue >= ushort.MinValue & integerValue <= ushort.MaxValue)
        {
            uIntegerValue = (ushort)integerValue;
            Console.WriteLine(uIntegerValue);
        }
        else
        {
            Console.WriteLine($"Unable to convert {integerValue} to a UInt16t.");
        }
        // </Snippet1>
    }
}
