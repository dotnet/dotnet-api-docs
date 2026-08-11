using System;
using System.Runtime.InteropServices;

public class IntPtrSubtractionExample
{
    public static void Run()
    {
        // <Snippet2>
        int[] arr = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        unsafe
        {
            fixed (int* parr = &arr[arr.GetUpperBound(0)])
            {
                IntPtr ptr = new(parr);
                for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
                {
                    IntPtr newPtr = ptr - ctr * sizeof(int);
                    Console.Write($"{Marshal.ReadInt32(newPtr)}   ");
                }
            }
        }
        // The example displays the following output:
        //       20   18   16   14   12   10   8   6   4   2
        // </Snippet2>
    }
}
