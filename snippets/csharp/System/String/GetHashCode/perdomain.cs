// <Snippet2>
using System;

public class Example
{
    public static void Main()
    {
        // Show hash code in current domain.
        DisplayString display = new();
        display.ShowStringHashCode();

        // Create a new app domain and show string hash code.
        AppDomain domain = AppDomain.CreateDomain("NewDomain");
        var display2 = (DisplayString)domain.CreateInstanceAndUnwrap(typeof(Example).Assembly.FullName,
                                                            "DisplayString");
        display2.ShowStringHashCode();
    }
}

public class DisplayString : MarshalByRefObject
{
    private string s = "This is a string.";

    public override bool Equals(object obj)
    {
        string s2 = obj as string;
        if (s2 == null)
            return false;
        else
            return s == s2;
    }

    public bool Equals(string str) => s == str;

    public override int GetHashCode() => s.GetHashCode();

    public override string ToString() => s;

    public void ShowStringHashCode() => Console.WriteLine($"String '{s}' in domain '{AppDomain.CurrentDomain.FriendlyName}': {s.GetHashCode():X8}");
}
// </Snippet2>
