//<Snippet1>
using System;
using System.Runtime.InteropServices;

public class Example
{
    public static void Main()
    {
        DisplayLayoutAttribute(typeof(Example).StructLayoutAttribute);
        DisplayLayoutAttribute(typeof(Test1).StructLayoutAttribute);
        DisplayLayoutAttribute(typeof(Test2).StructLayoutAttribute);
    }

    private static void DisplayLayoutAttribute(StructLayoutAttribute sla) => Console.WriteLine("\r\nCharSet: " + sla.CharSet + "\r\n   Pack: " + sla.Pack + "\r\n   Size: " + sla.Size + "\r\n  Value: " + sla.Value);
    public struct Test1
    {
        public byte B1;
        public short S;
        public byte B2;
    }
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct Test2
    {
        [FieldOffset(0)] public byte B1;
        [FieldOffset(1)] public short S;
        [FieldOffset(3)] public byte B2;
    }
}
//</Snippet1>
