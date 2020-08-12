﻿//<Snippet3>
// Example of the BitConverter.ToInt64 method.
using System;

class BytesToInt64Demo
{
    const string formatter = "{0,5}{1,27}{2,24}";

    // Convert eight byte array elements to a long and display it.
    public static void BAToInt64( byte[ ] bytes, int index )
    {
        long value = BitConverter.ToInt64( bytes, index );

        Console.WriteLine( formatter, index,
            BitConverter.ToString( bytes, index, 8 ), value );
    }

    // Display a byte array, using multiple lines if necessary.
    public static void WriteMultiLineByteArray( byte[ ] bytes )
    {
        const int rowSize = 20;
        int iter;

        Console.WriteLine( "initial byte array" );
        Console.WriteLine( "------------------" );

        for( iter = 0; iter < bytes.Length - rowSize; iter += rowSize )
        {
            Console.Write(
                BitConverter.ToString( bytes, iter, rowSize ) );
            Console.WriteLine( "-" );
        }

        Console.WriteLine( BitConverter.ToString( bytes, iter ) );
        Console.WriteLine( );
    }

    public static void Main( )
    {
        byte[ ] byteArray = {
              0,  54, 101, 196, 255, 255, 255, 255,   0,   0,
              0,   0,   0,   0,   0,   0, 128,   0, 202, 154,
             59,   0,   0,   0,   0,   1,   0,   0,   0,   0,
            255, 255, 255, 255,   1,   0,   0, 255, 255, 255,
            255, 255, 255, 255, 127,  86,  85,  85,  85,  85,
             85, 255, 255, 170, 170, 170, 170, 170, 170,   0,
              0, 100, 167, 179, 182, 224,  13,   0,   0, 156,
             88,  76,  73,  31, 242 };

        Console.WriteLine(
            "This example of the BitConverter.ToInt64( byte[ ], " +
            "int ) \nmethod generates the following output. It " +
            "converts elements \nof a byte array to long values.\r\n" );

        WriteMultiLineByteArray( byteArray );

        Console.WriteLine( formatter, "index", "array elements", "long" );
        Console.WriteLine( formatter, "-----", "--------------", "----" );

        // Convert byte array elements to long values.
        BAToInt64( byteArray, 8 );
        BAToInt64( byteArray, 5 );
        BAToInt64( byteArray, 34 );
        BAToInt64( byteArray, 17 );
        BAToInt64( byteArray, 0 );
        BAToInt64( byteArray, 21 );
        BAToInt64( byteArray, 26 );
        BAToInt64( byteArray, 53 );
        BAToInt64( byteArray, 45 );
        BAToInt64( byteArray, 59 );
        BAToInt64( byteArray, 67 );
        BAToInt64( byteArray, 37 );
        BAToInt64( byteArray, 9 );
    }
}

/*
This example of the BitConverter.ToInt64( byte[ ], int )
method generates the following output. It converts elements
of a byte array to long values.

initial byte array
------------------
00-36-65-C4-FF-FF-FF-FF-00-00-00-00-00-00-00-00-80-00-CA-9A-
3B-00-00-00-00-01-00-00-00-00-FF-FF-FF-FF-01-00-00-FF-FF-FF-
FF-FF-FF-FF-7F-56-55-55-55-55-55-FF-FF-AA-AA-AA-AA-AA-AA-00-
00-64-A7-B3-B6-E0-0D-00-00-9C-58-4C-49-1F-F2

index             array elements                    long
-----             --------------                    ----
    8    00-00-00-00-00-00-00-00                       0
    5    FF-FF-FF-00-00-00-00-00                16777215
   34    01-00-00-FF-FF-FF-FF-FF               -16777215
   17    00-CA-9A-3B-00-00-00-00              1000000000
    0    00-36-65-C4-FF-FF-FF-FF             -1000000000
   21    00-00-00-00-01-00-00-00              4294967296
   26    00-00-00-00-FF-FF-FF-FF             -4294967296
   53    AA-AA-AA-AA-AA-AA-00-00         187649984473770
   45    56-55-55-55-55-55-FF-FF        -187649984473770
   59    00-00-64-A7-B3-B6-E0-0D     1000000000000000000
   67    00-00-9C-58-4C-49-1F-F2    -1000000000000000000
   37    FF-FF-FF-FF-FF-FF-FF-7F     9223372036854775807
    9    00-00-00-00-00-00-00-80    -9223372036854775808
*/
//</Snippet3>
