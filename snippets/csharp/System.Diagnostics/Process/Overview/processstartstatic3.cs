// This helper displays the arguments passed by the process-start sample.

using System;

namespace StartArgs
{
    class ArgsEcho
    {
        public static void Run(string[] args)
        {
            Console.WriteLine("Received the following arguments:\n");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"[{i}] = {args[i]}");
            }

            Console.WriteLine("\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
