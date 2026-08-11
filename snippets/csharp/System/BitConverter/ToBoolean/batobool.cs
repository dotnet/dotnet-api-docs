//<Snippet1>
using System;

class Example
{
    public static void Main()
    {
        // Define an array of byte values.
        byte[] bytes = { 0, 1, 2, 4, 8, 16, 32, 64, 128, 255 };

        Console.WriteLine($"{"index",5}{"array element",16}{"bool",10}\n");
        // Convert each array element to a Boolean value.
        for (int index = 0; index < bytes.Length; index++)
        {
            Console.WriteLine($"{index,5}{bytes[index],16:X2}{BitConverter.ToBoolean(bytes, index),10}");
        }
    }
}
// The example displays the following output:
//     index   array element      bool
//
//         0              00     False
//         1              01      True
//         2              02      True
//         3              04      True
//         4              08      True
//         5              10      True
//         6              20      True
//         7              40      True
//         8              80      True
//         9              FF      True
//</Snippet1>
