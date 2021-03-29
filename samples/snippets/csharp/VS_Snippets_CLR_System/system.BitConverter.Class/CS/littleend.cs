﻿//<Snippet2>
// Example of the BitConverter.IsLittleEndian field.
using System;

class LittleEndDemo
{
    public static void Main( )
    {
        Console.WriteLine(
            "This example of the BitConverter.IsLittleEndian field " +
            "generates \nthe following output when run on " +
            "x86-class computers.\n");
        Console.WriteLine( "IsLittleEndian:  {0}",
            BitConverter.IsLittleEndian );
    }
}

/*
This example of the BitConverter.IsLittleEndian field generates
the following output when run on x86-class computers.

IsLittleEndian:  True
*/
//</Snippet2>
