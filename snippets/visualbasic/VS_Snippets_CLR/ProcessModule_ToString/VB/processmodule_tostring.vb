﻿' System.Diagnostics.ProcessModule.ToString

' The following program demonstrates the use of 'ToString' property of 
' 'ProcessModule' class. It creates a notepad, gets the 'MainModule' and 
' all other modules of the process 'notepad.exe', displays 'ToString'
' for all the modules and the main module.

Imports System.Diagnostics

Class MyProcessModuleClass
    Public Shared Sub Main()
        Try
            ' <Snippet1>
            Using myProcess As New Process()
                ' Get the process start information of notepad.
                Dim myProcessStartInfo As New ProcessStartInfo("notepad.exe")
                ' Assign 'StartInfo' of notepad to 'StartInfo' of 'myProcess' object.
                myProcess.StartInfo = myProcessStartInfo
                ' Create a notepad.
                myProcess.Start()
                System.Threading.Thread.Sleep(1000)
                Dim myProcessModule As ProcessModule
                ' Get all the modules associated with 'myProcess'.
                Dim myProcessModuleCollection As ProcessModuleCollection = myProcess.Modules
                Console.WriteLine("ToString properties of the modules associated " +
                                  "with 'notepad' are:")
                ' Display the ToString of each of the modules.
                Dim i As Integer
                For i = 0 To myProcessModuleCollection.Count - 1
                    myProcessModule = myProcessModuleCollection(i)
                    Console.WriteLine(myProcessModuleCollection(i).ModuleName + " : " +
                                      myProcessModule.ToString())
                Next i
                ' Get the main module associated with 'myProcess'.
                myProcessModule = myProcess.MainModule
                ' Display the ToString of the main module.
                Console.WriteLine("The process's main module is : " + myProcessModule.ToString())
                myProcess.CloseMainWindow()
            End Using
            ' </Snippet1>
        Catch e As Exception
            Console.WriteLine($"Exception : {e.Message}")
        End Try
    End Sub
End Class
