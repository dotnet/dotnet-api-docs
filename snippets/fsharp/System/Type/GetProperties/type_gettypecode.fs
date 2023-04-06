module type_gettypecode

open System

// <Snippet1>
// Create an object of 'Type' class.
let myType1 = Type.GetType "System.Int32"
// Get the 'TypeCode' of the 'Type' class object created above.
let myTypeCode = Type.GetTypeCode myType1
printfn $"TypeCode is: {myTypeCode}"
// </Snippet1>
// <Snippet2>
// Get the properties of 'Type' class object.
let myPropertyInfo = Type.GetType("System.Type").GetProperties()
printfn "Properties of System.Type are:"
for pi in myPropertyInfo do
    printfn $"{pi}"
// </Snippet2>
// <Snippet3>
let myObject = Array.zeroCreate<obj> 3
myObject[0] <- 66
myObject[1] <- "puri"
myObject[2] <- 33.33
// Get the array of 'Type' class objects.
let myTypeArray = Type.GetTypeArray myObject
printfn "Full names of the 'Type' objects in the array are:"
for h in myTypeArray do
    printfn $"{h.FullName}"
// </Snippet3>
// <Snippet4>
try
    // Throws 'TypeLoadException' because of case-sensitive search.
    let myType2 = Type.GetType("sYSTem.iNT32", true, false)
    printfn $"{myType2.FullName}"
with :? TypeLoadException as e ->
    printfn $"{e.Message}"
// </Snippet4>