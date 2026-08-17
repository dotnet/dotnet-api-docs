// <Snippet1>
using System;
class ProgIdExample2
{
    public static void Run()
    {
        try
        {
            // Use the ProgID HKEY_CLASSES_ROOT\DirControl.DirList.1.
            string myString1 = "DIRECT.ddPalette.3";
            // Use a nonexistent ProgID WrongProgID.
            string myString2 = "WrongProgID";
            // Make a call to the method to get the type information of the given ProgID.
            Type myType1 = Type.GetTypeFromProgID(myString1, true);
            Console.WriteLine($"GUID for ProgID DirControl.DirList.1 is {myType1.GUID}.");
            // Throw an exception because the ProgID is invalid and the throwOnError
            // parameter is set to True.
            Type myType2 = Type.GetTypeFromProgID(myString2, true);
        }
        catch (Exception e)
        {
            Console.WriteLine("An exception occurred.");
            Console.WriteLine($"Source: {e.Source}");
            Console.WriteLine($"Message: {e.Message}");
        }
    }
}
// </Snippet1>
