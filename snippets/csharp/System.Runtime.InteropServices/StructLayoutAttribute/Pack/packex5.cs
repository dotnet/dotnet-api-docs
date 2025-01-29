// <Snippet6>
using System;

unsafe struct ExampleStruct5
{

    public byte b1;
    public byte b2;
    public int i3;
    public fixed byte a4[1];
    public decimal d5;
}

public class Example5
{
    public unsafe static void Main()
    {
        ExampleStruct5 ex = new();
        byte* addr = (byte*)&ex;
        Console.WriteLine("Size:      {0}", sizeof(ExampleStruct5));
        Console.WriteLine("b1 Offset: {0}", &ex.b1 - addr);
        Console.WriteLine("b2 Offset: {0}", &ex.b2 - addr);
        Console.WriteLine("i3 Offset: {0}", (byte*)&ex.i3 - addr);
        Console.WriteLine("a4 Offset: {0}", ex.a4 - addr);
        Console.WriteLine("d5 Offset: {0}", (byte*)&ex.d5 - addr);
    }
}
// The example displays the following output:
//
// .NET 5+:
//       Size:      32
//       b1 Offset: 0
//       b2 Offset: 1
//       i3 Offset: 4
//       a4 Offset: 8
//       d5 Offset: 16
//
// .NET Framework:
//       Size:      28
//       b1 Offset: 0
//       b2 Offset: 1
//       i3 Offset: 4
//       a4 Offset: 8
//       d5 Offset: 12
// </Snippet6>
