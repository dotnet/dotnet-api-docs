//<snippet1>
using System;
using System.Runtime.InteropServices;

// These functions specify SetLastError=true to propagate the last error from the p/invoke
// such that it can be retrieved using Marshal.GetLastPInvokeError().
internal static class Kernel32
{
    [DllImport(nameof(Kernel32), ExactSpelling = true, SetLastError = true)]
    internal static extern bool SetCurrentDirectoryW([MarshalAs(UnmanagedType.LPWStr)] string path);
}

internal static class libc
{
    [DllImport(nameof(libc), SetLastError = true)]
    internal static extern int chdir([MarshalAs(UnmanagedType.LPUTF8Str)] string path);
}

class Program
{
    public static void Main(string[] args)
    {
        // Call p/invoke with valid arguments.
        CallPInvoke(AppContext.BaseDirectory);

        // Call p/invoke with invalid arguments.
        CallPInvoke(string.Empty);
    }

    private static void CallPInvoke(string path)
    {
        if (OperatingSystem.IsWindows())
        {
            Console.WriteLine($"Calling SetCurrentDirectoryW with path '{path}'");
            Kernel32.SetCurrentDirectoryW(path);
        }
        else
        {
            Console.WriteLine($"Calling chdir with path '{path}'");
            libc.chdir(path);
        }

        // Get the last p/invoke error and display it.
        int error = Marshal.GetLastPInvokeError();
        Console.WriteLine($"Last p/invoke error: {error}");
    }
}
//</snippet1>
