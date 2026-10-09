using System;

string[] sampleArgs = args.Length > 1 ? args[1..] : [];

switch (args.Length > 0 ? args[0] : null)
{
    case "async":
        Process_StandardError.Class1.Run(sampleArgs);
        break;
    case "sync":
        Example.Run();
        break;
    default:
        Console.WriteLine("Specify: async or sync.");
        break;
}
