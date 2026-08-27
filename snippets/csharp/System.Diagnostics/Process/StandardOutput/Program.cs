using System;

switch (args.Length > 0 ? args[0] : null)
{
    case "redirect":
        StandardOutputExample.Run();
        break;
    case "async":
        AsyncExample.Run();
        break;
    case "sync":
        SyncExample.Run();
        break;
    default:
        Console.WriteLine("Specify: redirect, async, or sync.");
        break;
}
