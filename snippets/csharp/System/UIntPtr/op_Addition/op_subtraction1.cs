using System;

public class UIntPtrSubtractionExample
{
    public static void Run()
    {
        // <Snippet2>
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        UIntPtr ptr = (UIntPtr)arr[arr.GetUpperBound(0)];
        for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
        {
            UIntPtr newPtr = ptr - (nuint)ctr;
            Console.Write($"{newPtr}   ");
        }
        // </Snippet2>
    }
}
