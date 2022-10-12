//<snippet1>
// Sample for the Environment.ExpandEnvironmentVariables method
using System;

class Sample
{
    public static void Main()
    {
        // Keep this information secure!
        string query = "My system drive is %SystemDrive% and my system root is %SystemRoot%";

        string str = Environment.ExpandEnvironmentVariables(query);

        Console.WriteLine(str);
    }
}
/*
This example prints:

My system drive is C: and my system root is C:\WINDOWS
*/
//</snippet1>
