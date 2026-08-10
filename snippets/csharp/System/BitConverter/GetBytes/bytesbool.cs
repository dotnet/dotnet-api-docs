//<Snippet1>
using System;

class GetBytesBooleanDemo
{
    public static void Main()
    {
        // Define Boolean true and false values.
        bool[] values = { true, false };

        // Display the value and its corresponding byte array.
        Console.WriteLine($"{"Boolean",10}{"Bytes",16}\n");
        foreach (bool value in values)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Console.WriteLine($"{value,10}{BitConverter.ToString(bytes),16}");
        }
    }
}
// The example displays the following output:
//        Boolean           Bytes
//
//           True              01
//          False              00
//</Snippet1>
