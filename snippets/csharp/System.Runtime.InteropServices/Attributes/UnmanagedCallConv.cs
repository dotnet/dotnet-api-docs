using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal static class Cdecl
{
    //<SnippetCdecl>
    // Target will be invoked using the cdecl calling convention
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
    [DllImport("NativeLibrary", EntryPoint = "native_function_cdecl")]
    internal static extern int NativeFunction(int arg);

    // Target will be invoked using the cdecl calling convention and with the GC transition suppressed
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition) })]
    [DllImport("NativeLibrary", EntryPoint = "native_function_cdecl")]
    internal static extern int NativeFunction_NoGCTransition(int arg);
    //</SnippetCdecl>
}

internal static class Stdcall
{
    //<SnippetStdcall>
    // Target will be invoked using the stdcall calling convention
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvStdcall) })]
    [DllImport("NativeLibrary", EntryPoint = "native_function_stdcall")]
    internal static extern int NativeFunction(int arg);

    // Target will be invoked using the stdcall calling convention and with the GC transition suppressed
    [UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition) })]
    [DllImport("NativeLibrary", EntryPoint = "native_function_stdcall")]
    internal static extern int NativeFunction_NoGCTransition(int arg);
    //</SnippetStdcall>
}
