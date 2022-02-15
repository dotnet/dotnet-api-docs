module getvalues_reflectiononly

// <Snippet3>
open System
open System.Reflection

let assem = Assembly.ReflectionOnlyLoadFrom @".\Enumerations.dll"
let typ = assem.GetType "Pets"
let fields = typ.GetFields()

for field in fields do
    if not (field.Name.Equals "value__") then

        printfn $"""{field.Name + ":",-9} {field.GetRawConstantValue()}"""
// The example displays the following output:
//       None:     0
//       Dog:      1
//       Cat:      2
//       Rodent:   4
//       Bird:     8
//       Fish:     16
//       Reptile:  32
//       Other:    64
// </Snippet3>

// <Snippet2>
[<Flags>] 
type Pets =
    | None = 0
    | Dog = 1
    | Cat = 2
    | Rodent = 4
    | Bird = 8
    | Fish = 16
    | Reptile = 32
    | Other = 64
// </Snippet2>