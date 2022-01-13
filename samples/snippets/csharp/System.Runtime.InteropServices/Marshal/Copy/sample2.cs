﻿//<SNIPPET1>
using System;
using System.Runtime.InteropServices;

class Example
{

    static void Main()
    {
        // Create a managed array.
        double[] managedArray = { 0.1, 0.2, 0.3, 0.4 };

        // Initialize unmanaged memory to hold the array.
        int size = Marshal.SizeOf(managedArray[0]) * managedArray.Length;

        IntPtr pnt = Marshal.AllocHGlobal(size);

        try
        {
            // Copy the array to unmanaged memory.
            Marshal.Copy(managedArray, 0, pnt, managedArray.Length);

            // Copy the unmanaged array back to another managed array.

            double[] managedArray2 = new double[managedArray.Length];

            Marshal.Copy(pnt, managedArray2, 0, managedArray.Length);

            Console.WriteLine("The array was copied to unmanaged memory and back.");
        }
        finally
        {
            // Free the unmanaged memory.
            Marshal.FreeHGlobal(pnt);
        }
    }
}
//</SNIPPET1>