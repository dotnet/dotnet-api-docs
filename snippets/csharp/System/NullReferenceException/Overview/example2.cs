// <Snippet3>
using System.Collections.Generic;

public class NRE2Example
{
    public static void Main()
    {
        List<string> names = GetData();
        PopulateNames(names);
    }

    private static void PopulateNames(List<string> names)
    {
        string[] arrNames = [ "Dakota", "Samuel", "Nikita",
                            "Koani", "Saya", "Yiska", "Yumaevsky" ];
        foreach (string arrName in arrNames)
            names.Add(arrName);
    }

    private static List<string> GetData()
    {
        return null;
    }
}

// The example displays output like the following:
//    Unhandled Exception: System.NullReferenceException: Object reference
//    not set to an instance of an object.
//       at NRE2Example.PopulateNames(List`1 names)
//       at NRE2Example.Main()
// </Snippet3>
