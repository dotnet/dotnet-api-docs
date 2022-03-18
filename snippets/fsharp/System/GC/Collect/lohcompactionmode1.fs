module lohcompactionmode1

open System
open System.Runtime

// <Snippet1>
GCSettings.LargeObjectHeapCompactionMode <- GCLargeObjectHeapCompactionMode.CompactOnce
GC.Collect()      
// </Snippet1>