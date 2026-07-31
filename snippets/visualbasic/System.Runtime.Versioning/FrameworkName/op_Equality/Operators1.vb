' Visual Basic .NET Document
Option Strict On

Imports System.Runtime.Versioning

Module Example
   Public Sub Main()
      TestForEquality()
      TestForInequality()
   End Sub

   Private Sub TestForEquality()
      ' <Snippet1>
      Dim version As New FrameworkName(".NET, Version=10.0")
      Dim actualVersion As New FrameworkName($".NET, Version={Environment.Version}")

      Console.WriteLine($"Given Version: {version}")
      Console.WriteLine($"Actual Version: {actualVersion}")
      If version = actualVersion Then
         Console.WriteLine("The versions are the same.")
      Else
         Console.WriteLine("The versions are different.")
      End If

      Console.WriteLine()

      ' The example displays output similar to the following:

      ' Given Version: .NET,Version=v10.0
      ' Actual Version: .NET,Version=v10.0.10
      ' The versions are different.

      ' </Snippet1>
   End Sub

   Private Sub TestForInequality()
      ' <Snippet2>
      Dim version As New FrameworkName(".NET, Version=10.0")
      Dim actualVersion As New FrameworkName($".NET, Version={Environment.Version}")

      Console.WriteLine($"Given Version: {version}")
      Console.WriteLine($"Actual Version {actualVersion}")
      If version <> actualVersion Then
         Console.WriteLine("The versions are different.")
      Else
         Console.WriteLine("The versions are the same.")
      End If

      Console.WriteLine()

      ' The example displays output similar to the following:

      ' Given Version: .NET,Version=v10.0
      ' Actual Version: .NET,Version=v10.0.10
      ' The versions are different.

      ' </Snippet2>
   End Sub
End Module

