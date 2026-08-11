// <Snippet2>
using System;
using System.Runtime.InteropServices;

public class BadCallExample
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
    public static extern int MessageBox(IntPtr hwnd, string text, string caption, uint type);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
    public static extern int MessageBoxW(IntPtr hwnd, string text, string caption, uint type);

    public static void Run()
    {
        try
        {
            MessageBox(new IntPtr(0), "Calling the MessageBox Function", "Example", 0);
        }
        catch (EntryPointNotFoundException e)
        {
            Console.WriteLine($"{e.GetType().Name}:\n   {e.Message}");
        }

        try
        {
            MessageBoxW(new IntPtr(0), "Calling the MessageBox Function", "Example", 0);
        }
        catch (EntryPointNotFoundException e)
        {
            Console.WriteLine($"{e.GetType().Name}:\n   {e.Message}");
        }
    }
}
// </Snippet2>
