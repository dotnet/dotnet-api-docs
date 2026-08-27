// Place this code into a console project named ArgsEcho to build the argsecho.exe target.

using System;

Console.WriteLine("Received the following arguments:\n");

for (int i = 0; i < args.Length; i++)
{
    Console.WriteLine($"[{i}] = {args[i]}");
}

Console.WriteLine("\nPress any key to exit");
Console.ReadLine();
