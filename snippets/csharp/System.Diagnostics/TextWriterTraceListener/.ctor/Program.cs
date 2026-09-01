using System;

string[] sampleArgs = args.Length > 1 ? args[1..] : [];

switch (args.Length > 0 ? args[0] : null)
{
    case "basic":
        TextWriterTraceListenerSample.Run();
        break;
    case "writer":
        Sample.Run(sampleArgs);
        break;
    case "stream":
        TWTLConStreamMod.Run(sampleArgs);
        break;
    case "named-stream":
        TWTLConStreamNameMod.Run(sampleArgs);
        break;
    case "file":
        TWTLConStringMod.Run(sampleArgs);
        break;
    case "named-file":
        TWTLConStringNameMod.Run(sampleArgs);
        break;
    case "named-writer":
        TWTLConWriterNameMod.Run(sampleArgs);
        break;
    default:
        Console.WriteLine(
            "Specify: basic, writer, stream, named-stream, file, named-file, or named-writer.");
        break;
}
