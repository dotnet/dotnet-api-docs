open System
open System.Runtime

// <Snippet1>
if GCSettings.LatencyMode = GCLatencyMode.NoGCRegion then
    GC.EndNoGCRegion()
// </Snippet1>
