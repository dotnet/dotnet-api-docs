module example1

// <Snippet6>
open System.Reflection

[<assembly: AssemblyVersionAttribute "2.0.1">]
do ()

type Example1 = class end

let thisAssem = typeof<Example1>.Assembly
let thisAssemName = thisAssem.GetName()
   
let ver = thisAssemName.Version
   
printfn $"This is version {ver} of {thisAssemName.Name}."
// The example displays the following output:
//        This is version 2.0.1.0 of Example1.
// </Snippet6>