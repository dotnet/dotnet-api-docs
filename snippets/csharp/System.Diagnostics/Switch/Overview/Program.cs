using System;

switch (args.Length > 0 ? args[0] : null)
{
    case "remarks":
        SomeClass.Run();
        break;
    case "overview":
        Class1.Run();
        break;
    default:
        Console.WriteLine("Specify: remarks or overview.");
        break;
}
