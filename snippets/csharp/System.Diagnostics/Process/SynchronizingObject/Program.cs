using System;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        switch (args.Length > 0 ? args[0] : null)
        {
            case "button":
                ProcessSynchronizingObject.Form1.Run();
                break;
            case "form":
                SynchronizingObjectTest.SyncForm.Run();
                break;
            default:
                Console.WriteLine("Specify: button or form.");
                break;
        }
    }
}
