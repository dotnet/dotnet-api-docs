using System;

public class UIntPtrAdditionExample
{
    public static void Run()
    {
        // <Snippet1>
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        UIntPtr ptr = (UIntPtr)arr[0];
        for (int ctr = 0; ctr < arr.Length; ctr++)
        {
            UIntPtr newPtr = ptr + (nuint)ctr;
            Console.WriteLine(newPtr);
        }
        // </Snippet1>
    }
}
