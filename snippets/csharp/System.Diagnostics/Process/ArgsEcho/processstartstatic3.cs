// This console project builds the ArgsEcho.exe target.

using System;

Console.WriteLine("Received the following arguments:\n");

for (int i = 0; i < args.Length; i++)
{
    Console.WriteLine($"[{i}] = {args[i]}");
}

Console.WriteLine("\nPress any key to exit");
Console.ReadLine();
