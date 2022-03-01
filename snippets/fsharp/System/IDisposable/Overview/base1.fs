module base1

// <Snippet3>
open Microsoft.Win32.SafeHandles
open System

type BaseClass1() =
    // Flag: Has Dispose already been called?
    let mutable disposed = false

    // Instantiate a SafeHandle instance.
    let handle = new SafeFileHandle(IntPtr.Zero, true)

    interface IDisposable with
        // Public implementation of Dispose pattern callable by consumers.
        member this.Dispose() =
            this.Dispose true
            GC.SuppressFinalize this

    // Implementation of Dispose pattern.
    abstract Dispose: bool -> unit
    override _.Dispose(disposing) =
        if not disposed then
            if disposing then
                handle.Dispose()
                // Free any other managed objects here.
            disposed <- true

// </Snippet3>