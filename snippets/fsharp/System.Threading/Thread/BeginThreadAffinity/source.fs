//<Snippet1>
open System.Threading

let performTask () =
    // Code that does not have thread affinity goes here.
    //
    Thread.BeginThreadAffinity()
    //
    // Code that has thread affinity goes here.
    //
    Thread.EndThreadAffinity()
    //
    // More code that does not have thread affinity.
//</Snippet1>
