//<snippet1>
open System
open System.Threading
open System.Runtime.InteropServices

// A simple module that exposes two static Win32 functions.
// One is a delegate type and the other is an enumerated type.
module MyWin32 =
    // An enumerated type for the control messages
    // sent to the handler routine.
    type CtrlTypes =
        | CTRL_C_EVENT = 0
        | CTRL_BREAK_EVENT = 1
        | CTRL_CLOSE_EVENT = 2
        | CTRL_LOGOFF_EVENT = 5
        | CTRL_SHUTDOWN_EVENT = 6

    // A delegate type to be used as the handler routine for SetConsoleCtrlHandler.
    type HandlerRoutine = delegate of CtrlTypes -> bool

    // Declare the SetConsoleCtrlHandler function
    // as external and receiving a delegate.
    [<DllImport "Kernel32">]
    extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add)

// A private static handler function in the MyApp class.
let handler (ctrlType: MyWin32.CtrlTypes) =
    let message =
        // Pattern match to handle the event type.
        match ctrlType with
        | MyWin32.CtrlTypes.CTRL_C_EVENT ->
            "A CTRL_C_EVENT was raised by the user."
        | MyWin32.CtrlTypes.CTRL_BREAK_EVENT ->
            "A CTRL_BREAK_EVENT was raised by the user."
        | MyWin32.CtrlTypes.CTRL_CLOSE_EVENT ->
            "A CTRL_CLOSE_EVENT was raised by the user."
        | MyWin32.CtrlTypes.CTRL_LOGOFF_EVENT ->
            "A CTRL_LOGOFF_EVENT was raised by the user."
        | MyWin32.CtrlTypes.CTRL_SHUTDOWN_EVENT ->
            "A CTRL_SHUTDOWN_EVENT was raised by the user."
        | _ -> "This message should never be seen!"

    // Use interop to display a message for the type of event.
    printfn $"{message}"
    true

// Use interop to set a console control handler.
let hr = MyWin32.HandlerRoutine handler
MyWin32.SetConsoleCtrlHandler(hr, true) |> ignore

// Give the user some time to raise a few events.
printfn "Waiting 30 seconds for console ctrl events..."

// The object hr is not referred to again.
// The garbage collector can detect that the object has no
// more managed references and might clean it up here while
// the unmanaged SetConsoleCtrlHandler method is still using it.

// Force a garbage collection to demonstrate how the hr
// object will be handled.
GC.Collect()
GC.WaitForPendingFinalizers()
GC.Collect()

Thread.Sleep 30000

// Display a message to the console when the unmanaged method
// has finished its work.
printfn "Finished!"

// Call GC.KeepAlive(hr) at this point to maintain a reference to hr.
// This will prevent the garbage collector from collecting the
// object during the execution of the SetConsoleCtrlHandler method.
GC.KeepAlive hr
Console.Read() |> ignore
//</snippet1>