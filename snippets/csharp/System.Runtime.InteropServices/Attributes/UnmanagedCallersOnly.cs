using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal static class UnmanagedCallersOnly
{
    //<SnippetUnmanagedCallersOnly>
    [DllImport("NativeLibrary")]
    internal static extern unsafe void NativeFunctionWithCallback(delegate* unmanaged[Cdecl]<int, int> callback);

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static int DoubleInt(int i) => i * 2;

    public static unsafe void PassCallbackToNativeFunction()
    {
        NativeFunctionWithCallback(&DoubleInt);
    }
    //</SnippetUnmanagedCallersOnly>
}
