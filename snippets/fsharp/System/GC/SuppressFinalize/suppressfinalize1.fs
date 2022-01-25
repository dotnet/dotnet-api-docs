// <Snippet1>
open System
open System.ComponentModel
open System.Runtime.InteropServices

[<DllImport("kernel32.dll", SetLastError = true)>]
extern IntPtr GetStdHandle(int nStdHandle)

[<DllImport("kernel32.dll", SetLastError = true)>]
extern bool WriteConsole(IntPtr hConsoleOutput, string lpBuffer, uint nNumberOfCharsToWrite, uint& lpNumberOfCharsWritten, IntPtr lpReserved)

[<DllImport("kernel32.dll", SetLastError = true)>]
extern bool CloseHandle(IntPtr handle)

type ConsoleMonitor() =
    let STD_INPUT_HANDLE = -10
    let STD_OUTPUT_HANDLE = -11
    let STD_ERROR_HANDLE = -12

    let handle =
        let h = GetStdHandle STD_OUTPUT_HANDLE
        if h = IntPtr.Zero then
            raise (InvalidOperationException "A console handle is not available.")
        else
            h

    let comp = new Component()
    let output = "The ConsoleMonitor class constructor.\n"
    let mutable disposed = false
    let mutable written = 0u
    do
        WriteConsole(handle, output, uint output.Length, &written, IntPtr.Zero)
        |> ignore

    // The finalizer represents Object.Finalize override.
    override this.Finalize() =
        if handle <> IntPtr.Zero then
            let output = "The ConsoleMonitor finalizer.\n"
            let mutable written = 0u
            WriteConsole(handle, output, uint output.Length, &written, IntPtr.Zero)
            |> ignore
        else
            eprintfn "Object finalization."
        this.Dispose false

    member _.Write() =
        let output = "The Write method.\n"
        let mutable written = 0u

        WriteConsole(handle, output, uint output.Length, &written, IntPtr.Zero)
        |> ignore

    member _.Dispose(disposing: bool) =
        let output = $"The Dispose({disposing}) method.\n"
        let mutable written = 0u

        WriteConsole(handle, output, uint output.Length, &written, IntPtr.Zero)
        |> ignore

        // Execute if resources have not already been disposed.
        if not disposed then
            // If the call is from Dispose, free managed resources.
            if disposing then
                eprintfn "Disposing of managed resources."
                if comp <> null then comp.Dispose()
            // Free unmanaged resources.
            let output = "Disposing of unmanaged resources."

            WriteConsole(handle, output, uint output.Length, &written, IntPtr.Zero)
            |> ignore

            if handle <> IntPtr.Zero then
                if not (CloseHandle handle) then
                    eprintfn "Handle cannot be closed."

        disposed <- true

    member this.Dispose() =
        let output = "The Dispose method.\n"
        let mutable written = 0u

        WriteConsole(handle, output, uint output.Length, &written, IntPtr.Zero)
        |> ignore

        this.Dispose true
        GC.SuppressFinalize this

    interface IDisposable with
        member this.Dispose() = this.Dispose()

printfn "ConsoleMonitor instance...."
let monitor = new ConsoleMonitor()
monitor.Write()
monitor.Dispose()

// If the monitor.Dispose method is not called, the example displays the following output:
//       ConsoleMonitor instance....
//       The ConsoleMonitor class constructor.
//       The Write method.
//       The ConsoleMonitor finalizer.
//       The Dispose(False) method.
//       Disposing of unmanaged resources.
//
// If the monitor.Dispose method is called, the example displays the following output:
//       ConsoleMonitor instance....
//       The ConsoleMonitor class constructor.
//       The Write method.
//       The Dispose method.
//       The Dispose(True) method.
//       Disposing of managed resources.
//       Disposing of unmanaged resources.
// </Snippet1>
