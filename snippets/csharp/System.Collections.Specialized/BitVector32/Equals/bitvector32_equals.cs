// The following code example compares a BitVector32 with another BitVector32 and with an Int32.

// <snippet1>
using System;
using System.Collections.Specialized;

public class SamplesBitVector32
{

    public static void Main()
    {

        // Creates and initializes a BitVector32 with the value 123.
        // This is the BitVector32 that will be compared to different types.
        BitVector32 myBV = new(123);

        // Creates and initializes a new BitVector32 which will be set up as sections.
        BitVector32 myBVsect = new(0);

        // Compares myBV and myBVsect.
        Console.WriteLine($"myBV                 : {myBV}");
        Console.WriteLine($"myBVsect             : {myBVsect}");
        if (myBV.Equals(myBVsect))
            Console.WriteLine($"   myBV({myBV.Data}) equals myBVsect({myBVsect.Data}).");
        else
            Console.WriteLine($"   myBV({myBV.Data}) does not equal myBVsect({myBVsect.Data}).");
        Console.WriteLine();

        // Assigns values to the sections of myBVsect.
        BitVector32.Section mySect1 = BitVector32.CreateSection(5);
        BitVector32.Section mySect2 = BitVector32.CreateSection(1, mySect1);
        BitVector32.Section mySect3 = BitVector32.CreateSection(20, mySect2);
        myBVsect[mySect1] = 3;
        myBVsect[mySect2] = 1;
        myBVsect[mySect3] = 7;

        // Compares myBV and myBVsect.
        Console.WriteLine($"myBV                 : {myBV}");
        Console.WriteLine($"myBVsect with values : {myBVsect}");
        if (myBV.Equals(myBVsect))
            Console.WriteLine($"   myBV({myBV.Data}) equals myBVsect({myBVsect.Data}).");
        else
            Console.WriteLine($"   myBV({myBV.Data}) does not equal myBVsect({myBVsect.Data}).");
        Console.WriteLine();

        // Compare myBV with an Int32.
        Console.WriteLine("Comparing myBV with an Int32: ");
        int myInt32 = 123;
        // Using Equals will fail because Int32 is not compatible with BitVector32.
        if (myBV.Equals(myInt32))
            Console.WriteLine($"   Using BitVector32.Equals, myBV({myBV.Data}) equals myInt32({myInt32}).");
        else
            Console.WriteLine($"   Using BitVector32.Equals, myBV({myBV.Data}) does not equal myInt32({myInt32}).");
        // To compare a BitVector32 with an Int32, use the "==" operator.
        if (myBV.Data == myInt32)
            Console.WriteLine($"   Using the \"==\" operator, myBV.Data({myBV.Data}) equals myInt32({myInt32}).");
        else
            Console.WriteLine($"   Using the \"==\" operator, myBV.Data({myBV.Data}) does not equal myInt32({myInt32}).");
    }
}

/*
This code produces the following output.

myBV                 : BitVector32{00000000000000000000000001111011}
myBVsect             : BitVector32{00000000000000000000000000000000}
   myBV(123) does not equal myBVsect(0).

myBV                 : BitVector32{00000000000000000000000001111011}
myBVsect with values : BitVector32{00000000000000000000000001111011}
   myBV(123) equals myBVsect(123).

Comparing myBV with an Int32:
   Using BitVector32.Equals, myBV(123) does not equal myInt32(123).
   Using the "==" operator, myBV.Data(123) equals myInt32(123).

*/
// </snippet1>
