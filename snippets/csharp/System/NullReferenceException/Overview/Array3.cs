﻿using System;

public class Array3Example
{
    public static void Main()
    {
        // <Snippet10>
        int[] values = null;
        for (int ctr = 0; ctr <= 9; ctr++)
            values[ctr] = ctr * 2;

        foreach (int value in values)
            Console.WriteLine(value);

        // The example displays the following output:
        //    Unhandled Exception:
        //       System.NullReferenceException: Object reference not set to an instance of an object.
        //       at Array3Example.Main()
        // </Snippet10>
    }
}
