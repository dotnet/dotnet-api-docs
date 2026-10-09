using System;

class Sample
{
    public static void Main()
    {
        //<snippet1>
        string s1 = "abcd";
        string s2 = "";
        string s3 = null;

        Console.WriteLine($"String s1 {Test(s1)}.");
        Console.WriteLine($"String s2 {Test(s2)}.");
        Console.WriteLine($"String s3 {Test(s3)}.");

        string Test(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "is null or empty";
            else
                return $"(\"{s}\") is neither null nor empty";
        }

        // The example displays the following output:
        //       String s1 ("abcd") is neither null nor empty.
        //       String s2 is null or empty.
        //       String s3 is null or empty.
        // </snippet1>
    }
}
