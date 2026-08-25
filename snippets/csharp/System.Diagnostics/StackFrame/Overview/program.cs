//<Snippet1>
using System;
using System.Diagnostics;

namespace StackFrameExample
{
    class Program
    {
        public static void Run(string[] args)
        {
            try
            {
                Method1();
            }
            catch (Exception)
            {
                StackTrace st = new();
                StackTrace st1 = new(new StackFrame(true));
                Console.WriteLine(" Stack trace for Main: {0}",
                   st1.ToString());
                Console.WriteLine(st.ToString());
            }
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
        private static void Method1()
        {
            try
            {
                Method2(4);
            }
            catch (Exception)
            {
                StackTrace st = new();
                StackTrace st1 = new(new StackFrame(true));
                Console.WriteLine(" Stack trace for Method1: {0}",
                   st1.ToString());
                Console.WriteLine(st.ToString());
                // Build a stack trace for the next frame.
                StackTrace st2 = new(new StackFrame(1, true));
                Console.WriteLine(" Stack trace for next level frame: {0}",
                   st2.ToString());
                throw;
            }
        }
        private static void Method2(int count)
        {
            try
            {
                if (count < 5)
                    throw new ArgumentException("count too large", "count");
            }
            catch (Exception)
            {
                StackTrace st = new();
                StackTrace st1 = new(new StackFrame(2, true));
                Console.WriteLine(" Stack trace for Method2: {0}",
                   st1.ToString());
                Console.WriteLine(st.ToString());
                throw;
            }
        }
    }
}
//</Snippet1>

internal static class SampleRunner
{
    public static void Main(string[] args)
    {
        switch (args.Length > 0 ? args[0] : null)
        {
            case "overview":
                StackFrameExample.Program.Run(args[1..]);
                break;
            case "levels":
                SamplePublic.ConsoleApp.Run();
                break;
            default:
                Console.WriteLine("Specify: overview or levels.");
                break;
        }
    }
}
