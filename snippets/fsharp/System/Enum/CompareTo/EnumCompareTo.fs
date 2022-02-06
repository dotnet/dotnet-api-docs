//<snippet1>
type VehicleDoors =
    | Motorbike = 0
    | Sportscar = 2
    | Sedan = 4
    | Hatchback = 5

let myVeh = VehicleDoors.Sportscar
let yourVeh = VehicleDoors.Motorbike
let otherVeh = VehicleDoors.Sedan

printfn $"Does a {myVeh} have more doors than a {yourVeh}?"
printfn $"""{if myVeh.CompareTo yourVeh > 0 then "Yes" else "No"}\n"""

printfn $"Does a {myVeh} have more doors than a {otherVeh}?"
printfn $"""{if myVeh.CompareTo otherVeh > 0 then "Yes" else "No"}"""

// The example displays the following output:
//       Does a Sportscar have more doors than a Motorbike?
//       Yes
//
//       Does a Sportscar have more doors than a Sedan?
//       No
//</snippet1>