module idisposabledispose

//<snippet1>
// The following example demonstrates how to create
// a resource class that implements the IDisposable interface
// and the IDisposable.Dispose method.
open System
open System.ComponentModel
open System.Runtime.InteropServices

// Use interop to call the method necessary
// to clean up the unmanaged resource.
[<DllImport "Kernel32">]
extern Boolean CloseHandle(nativeint handle)

// A base class that implements IDisposable.
// By implementing IDisposable, you are announcing that
// instances of this type allocate scarce resources.
type MyResource(handle: nativeint) =
    // Pointer to an external unmanaged resource.
    let mutable handle = handle

    // Other managed resource this class uses.
    let comp = new Component()
    
    // Track whether Dispose has been called.
    let mutable disposed = false

    // Implement IDisposable.
    // Do not make this method virtual.
    // A derived class should not be able to override this method.
    interface IDisposable with
        member this.Dispose() =
            this.Dispose true
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize this

    // Dispose(bool disposing) executes in two distinct scenarios.
    // If disposing equals true, the method has been called directly
    // or indirectly by a user's code. Managed and unmanaged resources
    // can be disposed.
    // If disposing equals false, the method has been called by the
    // runtime from inside the finalizer and you should not reference
    // other objects. Only unmanaged resources can be disposed.
    abstract Dispose: bool -> unit
    override _.Dispose(disposing) =
        // Check to see if Dispose has already been called.
        if not disposed then
            // If disposing equals true, dispose all managed
            // and unmanaged resources.
            if disposing then
                // Dispose managed resources.
                comp.Dispose()

            // Call the appropriate methods to clean up
            // unmanaged resources here.
            // If disposing is false,
            // only the following code is executed.
            CloseHandle handle |> ignore
            handle <- IntPtr.Zero

            // Note disposing has been done.
            disposed <- true


    // This finalizer will run only if the Dispose method
    // does not get called.
    // It gives your base class the opportunity to finalize.
    // Do not provide finalizer in types derived from this class.
    override this.Finalize() =
        // Do not re-create Dispose clean-up code here.
        // Calling Dispose(disposing: false) is optimal in terms of
        // readability and maintainability.
        this.Dispose false
//</snippet1>