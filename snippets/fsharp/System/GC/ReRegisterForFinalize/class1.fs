//<snippet1>
open System

[<AllowNullLiteral>]
type MyFinalizeObject() =
    let mutable hasFinalized = false
    
    static member val CurrentInstance = null with get, set

    override this.Finalize() =
        if hasFinalized then
            printfn "First finalization"

            // Put this object back into a root by creating a reference to it.
            MyFinalizeObject.CurrentInstance <- this

            // Indicate that this instance has finalized once.
            hasFinalized <- true

            // Place a reference to this object back in the finalization queue.
            GC.ReRegisterForFinalize this
        else 
            printfn "Second finalization"

// Create a MyFinalizeObject.
let mutable mfo = MyFinalizeObject()

// Release the reference to mfo.
mfo <- null

// Force a garbage collection.
GC.Collect()

// At this point mfo will have gone through the first Finalize.
// There should now be a reference to mfo in the static
// MyFinalizeObject.CurrentInstance property. Setting this value
// to null and forcing another garbage collection will now
// cause the object to Finalize permanently.
MyFinalizeObject.CurrentInstance <- null
GC.Collect()
//</snippet1>