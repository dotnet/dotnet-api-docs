// <Snippet10>
using System;
using System.IO;
using System.Runtime.Versioning;

[assembly:TargetFramework(".NETFramework,Version=v4.6.2")]

public class Example
{
   public static void Main()
   {
      Console.WriteLine(Path.GetDirectoryName("file://c/temp/dirlist.txt"));
   }
}
// The example displays the following output:
//    Unhandled Exception: System.ArgumentException: The path is not of a legal form.
//       at System.IO.Path.NewNormalizePathLimitedChecks(string path, int maxPathLength, Boolean expandShortPaths)
//       at System.IO.Path.NormalizePath(string path, Boolean fullCheck, int maxPathLength, Boolean expandShortPaths)
//       at System.IO.Path.InternalGetDirectoryName(string path)
//       at Example.Main()
// </Snippet10>
