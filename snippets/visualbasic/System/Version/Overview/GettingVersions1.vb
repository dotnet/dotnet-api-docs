' Visual Basic .NET Document
Option Strict On

Imports System.Reflection

<Assembly: CLSCompliant(True)>
Module modMain

   Public Sub Main()
      GetOsVersion()
      Console.WriteLine()
      GetClrVersion()
      Console.WriteLine()
   End Sub

   Private Sub GetOsVersion()
      ' <Snippet1>
      ' Get the operating system version.
      Dim os As OperatingSystem = Environment.OSVersion
      Dim ver As Version = os.Version
      Console.WriteLine("Operating System: {0} ({1})", os.VersionString, ver.ToString())
      ' </Snippet1>
   End Sub

    Private Sub GetClrVersion()
        ' <Snippet2>
        ' Get the common language runtime version.
        Dim ver As Version = Environment.Version
        Console.WriteLine("CLR Version {0}", ver.ToString())
        ' </Snippet2>
    End Sub
End Module

Public Module Example4
    Public Sub GetExecutingAssemblyVersion()
        ' Get the version of the current assembly.
        Dim assem As Assembly = Assembly.GetExecutingAssembly()
        Dim assemName As AssemblyName = assem.GetName()
        Dim ver As Version = assemName.Version
        Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString())
    End Sub
End Module
