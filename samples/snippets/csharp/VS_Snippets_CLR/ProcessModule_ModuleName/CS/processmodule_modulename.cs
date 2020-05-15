﻿// System.Diagnostics.ProcessModule.ModuleName

/* The following program demonstrates the use of 'ModuleName' property of
   'ProcessModule' class. It creates a notepad, gets the 'MainModule' and
   all other modules of the process 'notepad.exe', displays 'ModuleName'
   for all the modules and the main module.
*/
using System;
using System.Diagnostics;

class MyProcessModuleClass
{
    public static void Main()
    {
        try
        {
            // <Snippet1>
            using (Process myProcess = new Process())
            {
                // Get the process start information of notepad.
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("notepad.exe");
                // Assign 'StartInfo' of notepad to 'StartInfo' of 'myProcess' object.
                myProcess.StartInfo = myProcessStartInfo;
                // Create a notepad.
                myProcess.Start();
                System.Threading.Thread.Sleep(1000);
                ProcessModule myProcessModule;
                // Get all the modules associated with 'myProcess'.
                ProcessModuleCollection myProcessModuleCollection = myProcess.Modules;
                Console.WriteLine("Module names of the modules associated "
                    + "with 'notepad' are:");
                // Display the 'ModuleName' of each of the modules.
                for (int i = 0; i < myProcessModuleCollection.Count; i++)
                {
                    myProcessModule = myProcessModuleCollection[i];
                    Console.WriteLine(myProcessModule.ModuleName);
                }
                // Get the main module associated with 'myProcess'.
                myProcessModule = myProcess.MainModule;
                // Display the 'ModuleName' of the main module.
                Console.WriteLine("The process's main moduleName is: " + myProcessModule.ModuleName);
                myProcess.CloseMainWindow();
            }
            // </Snippet1>
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception : {e.Message}");
        }
    }
}
