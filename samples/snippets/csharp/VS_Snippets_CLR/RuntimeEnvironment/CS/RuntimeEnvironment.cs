﻿//Types:System.Runtime.InteropServices.RuntimeEnvironment
//<snippet1>
using System;
using System.Reflection;
using System.Runtime.InteropServices;

public sealed class App
{
    static void Main()
    {
        //<snippet2>
        // Show whether the EXE assembly was loaded from the GAC or from a private subdirectory.
        Assembly assem = typeof(App).Assembly;
        Console.WriteLine("Did the {0} assembly load from the GAC? {1}",
           assem, RuntimeEnvironment.FromGlobalAccessCache(assem));
        //</snippet2>

        //<snippet3>
        // Show the path where the CLR was loaded from.
        Console.WriteLine("Runtime directory: {0}", RuntimeEnvironment.GetRuntimeDirectory());
        //</snippet3>

        //<snippet4>
        // Show the CLR's version number.
        Console.WriteLine("System version: {0}", RuntimeEnvironment.GetSystemVersion());
        //</snippet4>

        //<snippet5>
        // Show the path of the machine's configuration file.
        Console.WriteLine("System configuration file: {0}", RuntimeEnvironment.SystemConfigurationFile);
        //</snippet5>
    }
}

// This code produces the following output.
//
// Did the RuntimeEnvironment, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// assembly load from the GAC? False
// Runtime directory: C:\WINDOWS\Microsoft.NET\Framework\v2.0.40607\
// System version: v2.0.40607
// System configuration file: C:\WINDOWS\Microsoft.NET\Framework\v2.0.40607\config\
// machine.config
//</snippet1>