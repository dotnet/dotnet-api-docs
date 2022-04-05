//  <SNIPPET1>
open System

//Create evidence for new appdomain.
let adevidence = AppDomain.CurrentDomain.Evidence

//Create the new application domain.
let domain = AppDomain.CreateDomain("MyDomain", adevidence)

//Display the current relative search path.
printfn $"Relative search path is: {domain.RelativeSearchPath}"

//Append the relative path.
let Newpath = "www.code.microsoft.com"
domain.AppendPrivatePath Newpath

//Display the new relative search path.
printfn $"Relative search path is: {domain.RelativeSearchPath}"

//Clear the private search path.
domain.ClearPrivatePath()

//Display the new relative search path.
printfn $"Relative search path is now: {domain.RelativeSearchPath}"

AppDomain.Unload domain
//  </SNIPPET1>