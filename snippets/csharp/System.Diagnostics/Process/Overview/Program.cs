using System;

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
    default:
        Console.WriteLine("Specify: instance, static, or start-args-echo.");
        break;
}
