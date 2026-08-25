// This sample starts the argument-echo helper in the same snippet project.

using System;
using System.Diagnostics;

namespace StartArgsEcho
{
    class Program
    {
        public static void Run()
        {
            ProcessStartInfo startInfo = new(SampleProcess.FileName)
            {
                WindowStyle = ProcessWindowStyle.Normal,

                // Start with one argument.
                // Output of ArgsEcho:
                //  [0]=/a
                Arguments = SampleProcess.Arguments("/a")
            };
            Process.Start(startInfo);

            // Start with multiple arguments separated by spaces.
            // Output of ArgsEcho:
            //  [0] = /a
            //  [1] = /b
            //  [2] = c:\temp
            startInfo.Arguments = SampleProcess.Arguments("/a /b c:\\temp");
            Process.Start(startInfo);

            // An argument with spaces inside quotes is interpreted as multiple arguments.
            // Output of ArgsEcho:
            //  [0] = /a
            //  [1] = literal string arg
            startInfo.Arguments = SampleProcess.Arguments("/a \"literal string arg\"");
            Process.Start(startInfo);

            // An argument inside double quotes is interpreted as if the quote weren't there,
            // that is, as separate arguments. Equivalent verbatim string is @"/a /b:""string with quotes"""
            // Output of ArgsEcho:
            //  [0] = /a
            //  [1] = /b:string
            //  [2] = in
            //  [3] = double
            //  [4] = quotes
            startInfo.Arguments = SampleProcess.Arguments("/a /b:\"\"string in double quotes\"\"");
            Process.Start(startInfo);

            // Triple-escape quotation marks to include the character in the final argument received
            // by the target process. Equivalent verbatim string: @"/a /b:""""""quoted string""""""";
            //  [0] = /a
            //  [1] = /b:"quoted string"
            startInfo.Arguments = SampleProcess.Arguments("/a /b:\"\"\"quoted string\"\"\"");
            Process.Start(startInfo);
        }
    }
}
