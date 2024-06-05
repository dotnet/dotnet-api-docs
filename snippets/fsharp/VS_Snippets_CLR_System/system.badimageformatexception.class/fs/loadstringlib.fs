module loadstringlib

// <Snippet3>
open System.Reflection

let title = "a tale of two cities"
      
// Load assembly containing StateInfo type.
let assem = Assembly.LoadFrom @".\StringLib.dll"

// Get type representing StateInfo class.
let stateInfoType = assem.GetType "StringLib"

// Get Display method.
let mi = stateInfoType.GetMethod "ToProperCase"

// Call the Display method.
let properTitle = 
   mi.Invoke(null, [| box title |]) :?> string

printfn $"{properTitle}"

// </Snippet3>