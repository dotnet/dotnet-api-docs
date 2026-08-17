using System;

public class ObjectReferenceEqualsExample2
{
    public static void Run()
    {
        // <Snippet2>
        string s1 = "String1";
        string s2 = "String1";
        Console.WriteLine($"s1 = s2: {object.ReferenceEquals(s1, s2)}");
        Console.WriteLine($"{s1} interned: {(string.IsNullOrEmpty(string.IsInterned(s1)) ? "No" : "Yes")}");

        string suffix = "A";
        string s3 = "String" + suffix;
        string s4 = "String" + suffix;
        Console.WriteLine($"s3 = s4: {object.ReferenceEquals(s3, s4)}");
        Console.WriteLine($"{s3} interned: {(string.IsNullOrEmpty(string.IsInterned(s3)) ? "No" : "Yes")}");

        // The example displays the following output:
        //       s1 = s2: True
        //       String1 interned: Yes
        //       s3 = s4: False
        //       StringA interned: No
        // </Snippet2>
    }
}
