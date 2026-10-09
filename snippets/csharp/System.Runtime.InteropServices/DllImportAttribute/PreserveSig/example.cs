//<snippet1>
using System;
using System.Runtime.InteropServices;

internal class Win32
{
    // The SHAutoComplete function allows you
    // to add auto-compete functionality to your
    // Windows Forms text boxes.

    // For the complete set of flags,
    // see the documentation of the
    // SHAutoComplete function.
    public enum SHAutoCompleteFlags
    {
        SHACF_DEFAULT = 0x00000000,
        SHACF_FILESYSTEM = 0x00000001
    }

    // Use the DllImportAttribute to import the SHAutoComplete function.
    // Set the PreserveSig to false to specify exception errors.
    [DllImportAttribute("shlwapi.dll", EntryPoint = "SHAutoComplete", ExactSpelling = true, PreserveSig = false)]
    public static extern void SHAutoComplete(IntPtr hwndEdit, SHAutoCompleteFlags dwFlags);

    // Use the DllImportAttribute to import the SHAutoComplete function.
    // Use the default value of the PreserveSig field to specify HRESULT errors.
    [DllImportAttribute("shlwapi.dll", EntryPoint = "SHAutoComplete", ExactSpelling = true)]
    public static extern int SHAutoCompleteHRESULT(IntPtr hwndEdit, SHAutoCompleteFlags dwFlags);
}

static class Program
{
    static void Main()
    {
        Run();
    }

    static void Run()
    {
        // Create a null (nothing in Visual Basic) IntPtr
        // to pass to the SHAutoComplete method.  Doing so
        // creates a failure and demonstrates the two ways
        // that the PreserveSig property allows you to handle
        // failures.
        // Normally, you would pass a handle to a managed
        // Windows Forms text box.
        IntPtr iPtr = new IntPtr(0);

        // Call the SHAutoComplete function using exceptions.
        try
        {
            Console.WriteLine("Calling the SHAutoComplete method with the PreserveSig field set to false.");

            Win32.SHAutoComplete(iPtr, Win32.SHAutoCompleteFlags.SHACF_DEFAULT);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception handled: " + e.Message);
        }

        Console.WriteLine("Calling the SHAutoComplete method with the PreserveSig field set to true.");

        // Call the SHAutoComplete function using HRESULTS.
        int HRESULT = Win32.SHAutoCompleteHRESULT(iPtr, Win32.SHAutoCompleteFlags.SHACF_DEFAULT);

        Console.WriteLine("HRESULT handled: " + HRESULT.ToString());
    }
}
//</snippet1>
