//<Snippet1>
using System;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

class SafeHandlesExample
{
    static void Main()
    {
        UnmanagedMutex uMutex = new("YourCompanyName_SafeHandlesExample_MUTEX");

        try
        {
            uMutex.Create();
            Console.WriteLine("Mutex created. Press Enter to release it.");
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            uMutex.Release();
            Console.WriteLine("Mutex released.");
        }
    }
}

partial class UnmanagedMutex(string Name)
{
    // Use interop to call the CreateMutex function.
    [LibraryImport("kernel32.dll", EntryPoint = "CreateMutexW", StringMarshalling = StringMarshalling.Utf16)]
    private static partial SafeWaitHandle CreateMutex(
        IntPtr lpMutexAttributes,
        [MarshalAs(UnmanagedType.Bool)] bool bInitialOwner,
        string lpName
        );

    // Use interop to call the ReleaseMutex function.
    // For more information about ReleaseMutex,
    // see the unmanaged MSDN reference library.
    [LibraryImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool ReleaseMutex(SafeWaitHandle hMutex);

    private SafeWaitHandle _handleValue = null;
    private readonly IntPtr _mutexAttrValue = IntPtr.Zero;
    private string nameValue = Name;

    public void Create()
    {
        ArgumentException.ThrowIfNullOrEmpty(nameValue);

        _handleValue = CreateMutex(_mutexAttrValue,
                                        true, nameValue);

        // If the handle is invalid,
        // get the last Win32 error
        // and throw a Win32Exception.
        if (_handleValue.IsInvalid)
        {
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }
    }

    public SafeWaitHandle Handle
    {
        get
        {
            if (!_handleValue.IsInvalid)
            {
                return _handleValue;
            }
            else
            {
                return null;
            }
        }
    }

    public string Name => nameValue;

    public void Release()
    {
        ReleaseMutex(_handleValue);
    }
}
//</Snippet1>
