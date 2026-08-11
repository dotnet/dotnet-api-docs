// <Snippet1>
using System;

public class GuidCompareToExample2
{
    public static void Run()
    {
        Guid mainGuid = Guid.Parse("01e75c83-c6f5-4192-b57e-7427cec5560d");
        unchecked
        {
            Guid guid2 = new(0x01e75c83, (short)0xc6f5,
                                  0x4192,
                                  new byte[] { 0xb5, 0x7e, 0x74, 0x27, 0xce, 0xc5, 0x56, 0x0c });
            Guid guid3 = Guid.Parse("01e75c84-c6f5-4192-b57e-7427cec5560d");

            Console.WriteLine($"{mainGuid} {(Comparison)mainGuid.CompareTo(guid2):F} {guid2}");
            Console.WriteLine($"{mainGuid} {(Comparison)mainGuid.CompareTo(guid3):F} {guid3}");
        }
    }

    private enum Comparison
    { LessThan = -1, Equals = 0, GreaterThan = 1 }
}
// The example displays the following output:
//    01e75c83-c6f5-4192-b57e-7427cec5560d GreaterThan 01e75c83-c6f5-4192-b57e-7427cec5560c
//    01e75c83-c6f5-4192-b57e-7427cec5560d LessThan 01e75c84-c6f5-4192-b57e-7427cec5560d
// </Snippet1>
