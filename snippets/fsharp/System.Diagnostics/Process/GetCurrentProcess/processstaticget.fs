// <Snippet1>
open System.Diagnostics

// Get the current process.
let currentProcess = Process.GetCurrentProcess()

// Get all processes running on the local computer.
let localAll = Process.GetProcesses()

// Get all instances of Notepad running on the local computer.
// This will return an empty array if notepad isn't running.
let localByName = Process.GetProcessesByName "notepad"

// Get a process on the local computer, using the process id.
// This will throw an exception if there is no such process.
let localById = Process.GetProcessById 1234

// Get processes running on a remote computer. Note that this
// and all the following calls will timeout and throw an exception
// if "myComputer" and 169.0.0.0 do not exist on your local network.

// Get all processes on a remote computer.
let remoteAll = Process.GetProcesses "myComputer"

// Get all instances of Notepad running on the specific computer, using machine name.
let remoteByName = Process.GetProcessesByName("notepad", "myComputer")

// Get all instances of Notepad running on the specific computer, using IP address.
let ipByName = Process.GetProcessesByName("notepad", "169.0.0.0")

// Get a process on a remote computer, using the process id and machine name.
let remoteById = Process.GetProcessById(2345, "myComputer")

// </Snippet1>
