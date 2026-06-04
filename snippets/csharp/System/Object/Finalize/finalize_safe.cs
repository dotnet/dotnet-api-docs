// <Snippet2>
using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

public class FileAssociationInfo : IDisposable
{
    // Private variables.
    private string openCmd;
    private string args;
    private SafeRegistryHandle hExtHandle, hAppIdHandle;

    // Windows API calls.
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int RegOpenKeyEx(IntPtr hKey,
                   string lpSubKey, int ulOptions, int samDesired,
                   out IntPtr phkResult);
    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW",
               SetLastError = true)]
    private static extern int RegQueryValueEx(IntPtr hKey,
                   string lpValueName, int lpReserved, out uint lpType,
                   string lpData, ref uint lpcbData);
    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern int RegSetValueEx(IntPtr hKey, [MarshalAs(UnmanagedType.LPStr)] string lpValueName,
                   int Reserved, uint dwType, [MarshalAs(UnmanagedType.LPStr)] string lpData,
                   int cpData);
    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern int RegCloseKey(UIntPtr hKey);

    // Windows API constants.
    private const int HKEY_CLASSES_ROOT = unchecked((int)0x80000000);
    private const int ERROR_SUCCESS = 0;

    private const int KEY_QUERY_VALUE = 1;
    private const int KEY_SET_VALUE = 0x2;

    private const uint REG_SZ = 1;

    private const int MAX_PATH = 260;

    public FileAssociationInfo(string fileExtension)
    {
        if (!fileExtension.StartsWith("."))
            fileExtension = "." + fileExtension;
        Extension = fileExtension;

        // Get the file extension value.
        int retVal = RegOpenKeyEx(new IntPtr(HKEY_CLASSES_ROOT), fileExtension, 0, KEY_QUERY_VALUE, out IntPtr hExtension);
        if (retVal != ERROR_SUCCESS)
            throw new Win32Exception(retVal);
        // Instantiate the first SafeRegistryHandle.
        hExtHandle = new SafeRegistryHandle(hExtension, true);

        string appId = new(' ', MAX_PATH);
        uint appIdLength = (uint)appId.Length;
        retVal = RegQueryValueEx(
            hExtHandle.DangerousGetHandle(),
            string.Empty,
            0,
            out _,
            appId,
            ref appIdLength);
        if (retVal != ERROR_SUCCESS)
            throw new Win32Exception(retVal);
        // We no longer need the hExtension handle.
        hExtHandle.Dispose();

        // Determine the number of characters without the terminating null.
        appId = appId.Substring(0, (int)appIdLength / 2 - 1) + @"\shell\open\Command";

        // Open the application identifier key.
        string exeName = new(' ', MAX_PATH);
        _ = (uint)exeName.Length;
        retVal = RegOpenKeyEx(
            new IntPtr(HKEY_CLASSES_ROOT),
            appId,
            0,
            KEY_QUERY_VALUE | KEY_SET_VALUE,
            out IntPtr hAppId);
        if (retVal != ERROR_SUCCESS)
            throw new Win32Exception(retVal);

        // Instantiate the second SafeRegistryHandle.
        hAppIdHandle = new SafeRegistryHandle(hAppId, true);

        // Get the executable name for this file type.
        string exePath = new(' ', MAX_PATH);
        uint exePathLength = (uint)exePath.Length;
        retVal = RegQueryValueEx(
            hAppIdHandle.DangerousGetHandle(),
            string.Empty,
            0,
            out _,
            exePath,
            ref exePathLength);
        if (retVal != ERROR_SUCCESS)
            throw new Win32Exception(retVal);

        // Determine the number of characters without the terminating null.
        exePath = exePath.Substring(0, (int)exePathLength / 2 - 1);
        // Remove any environment strings.
        exePath = Environment.ExpandEnvironmentVariables(exePath);

        int position = exePath.IndexOf('%');
        if (position >= 0)
        {
            args = exePath.Substring(position);
            // Remove command line parameters ('%0', etc.).
            exePath = exePath.Substring(0, position).Trim();
        }
        openCmd = exePath;
    }

    public string Extension { get; }

    public string Open
    {
        get { return openCmd; }
        set
        {
            if (hAppIdHandle.IsInvalid | hAppIdHandle.IsClosed)
                throw new InvalidOperationException("Cannot write to registry key.");
            if (!File.Exists(value))
            {
                string message = string.Format("'{0}' does not exist", value);
                throw new FileNotFoundException(message);
            }
            string cmd = value + " %1";
            int retVal = RegSetValueEx(
                hAppIdHandle.DangerousGetHandle(),
                string.Empty,
                0,
                REG_SZ,
                cmd,
                cmd.Length + 1);
            if (retVal != ERROR_SUCCESS)
                throw new Win32Exception(retVal);
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        // Ordinarily, you release unmanaged resources here,
        // but all are wrapped by safe handles.

        // Release disposable objects.
        if (disposing)
        {
            hExtHandle?.Dispose();
            hAppIdHandle?.Dispose();
        }
    }
}
// </Snippet2>

public class Example
{
    public static void Main()
    {
        FileAssociationInfo fa = new(".txt");
        Console.WriteLine($"{fa.Extension} files are handled by '{fa.Open}'");
        fa.Dispose();
    }
}
