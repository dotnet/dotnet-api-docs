module executeassembly

// <Snippet1>
open System

let currentDomain = AppDomain.CurrentDomain
let otherDomain = AppDomain.CreateDomain "otherDomain"

currentDomain.ExecuteAssembly "MyExecutable.exe"
// Prints "MyExecutable running on [default]"

otherDomain.ExecuteAssembly "MyExecutable.exe"
// Prints "MyExecutable running on otherDomain"
// </Snippet1>