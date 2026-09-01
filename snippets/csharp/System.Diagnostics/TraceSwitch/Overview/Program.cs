using System;

string[] sampleArgs = args.Length > 1 ? args[1..] : [];

switch (args.Length > 0 ? args[0] : null)
{
    case "remarks":
        TraceErr.Run(sampleArgs);
        break;
    case "overview":
        Form1.Run(sampleArgs);
        break;
    default:
        Console.WriteLine("Specify: remarks or overview.");
        break;
}
