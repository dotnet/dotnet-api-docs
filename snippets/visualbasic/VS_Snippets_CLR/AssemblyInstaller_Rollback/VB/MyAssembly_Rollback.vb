﻿'  The following example creates an assembly which is used to demonstrate
'  the methods, properties and constructors of the 'AssemblyInstaller' class.

Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.Collections

Namespace MyAssembly
   <RunInstallerAttribute(True)> Public Class MyProjectInstaller
      Inherits Installer
      Shared Sub Main()
         Console.WriteLine("Hello World")
      End Sub
   End Class
End Namespace 'MyAssembly