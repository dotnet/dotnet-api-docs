//  <SNIPPET1>
open System

let currentDomain = AppDomain.CurrentDomain
//Provide the current application domain evidence for the assembly.
let asEvidence = currentDomain.Evidence
//Load the assembly from the application directory using a simple name.

//Create an assembly called CustomLibrary to run this sample.
currentDomain.Load("CustomLibrary", asEvidence)

//Make an array for the list of assemblies.
let assems = currentDomain.GetAssemblies()

//List the assemblies in the current application domain.
printfn "List of assemblies loaded in current appdomain:"
for assem in assems do
    printfn $"{assem}"
//  </SNIPPET1>