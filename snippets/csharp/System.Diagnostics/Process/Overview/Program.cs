using System;
using System.Diagnostics;
using System.IO;

string[] sampleArgs = args.Length > 1 ? args[1..] : [];

switch (args.Length > 0 ? args[0] : null)
{
    case "instance":
        MyProcessSample.MyProcessInstanceSample.Run();
        break;
    case "static":
        MyProcessSample.MyProcessStaticSample.Run();
        break;
    case "start-args-echo":
        StartArgsEcho.Program.Run();
        break;
    case "args-echo":
        StartArgs.ArgsEcho.Run(sampleArgs);
        break;
    default:
        Console.WriteLine("Specify: instance, static, start-args-echo, or args-echo.");
        break;
}

internal static class SampleProcess
{
    private static readonly string s_executablePath =
        Environment.ProcessPath ?? throw new InvalidOperationException("The current process path isn't available.");

    public static string FileName => s_executablePath;

    public static string Arguments(string arguments)
    {
        string command = "args-echo";
        if (string.Equals(Path.GetFileNameWithoutExtension(s_executablePath), "dotnet",
            StringComparison.OrdinalIgnoreCase))
        {
            command = $"\"{typeof(SampleProcess).Assembly.Location}\" {command}";
        }

        return $"{command} {arguments}";
    }
}
