module source2

open System
open System.Collections.Generic

//<snippet03>
let allVehicles = HashSet<string> StringComparer.OrdinalIgnoreCase
let someVehicles = ResizeArray()

someVehicles.Add "Planes"
someVehicles.Add "Trains"
someVehicles.Add "Automobiles"

// Add in the vehicles contained in the someVehicles list.
allVehicles.UnionWith someVehicles

printfn "The current HashSet contains:\n"

for vehicle in allVehicles do
    printfn $"{vehicle}"

allVehicles.Add "Ships" |> ignore
allVehicles.Add "Motorcycles" |> ignore
allVehicles.Add "Rockets" |> ignore
allVehicles.Add "Helicopters" |> ignore
allVehicles.Add "Submarines" |> ignore

printfn "\nThe updated HashSet contains:\n"

for vehicle in allVehicles do
    printfn $"{vehicle}"

// Verify that the 'All Vehicles' set contains at least the vehicles in
// the 'Some Vehicles' list.
if allVehicles.IsSupersetOf someVehicles then
    printfn "\nThe 'All' vehicles set contains everything in 'Some' vehicles list."

// Check for Rockets. Here the OrdinalIgnoreCase comparer will compare
// true for the mixed-case vehicle type.
if allVehicles.Contains "roCKeTs" then
    printfn "\nThe 'All' vehicles set contains 'roCKeTs'"

allVehicles.ExceptWith someVehicles
printfn "\nThe excepted HashSet contains:\n"

for vehicle in allVehicles do
    printfn $"{vehicle}"

// Predicate to determine vehicle 'coolness'.
let isNotSuperCool vehicle =
    let superCool = vehicle = "Helicopters" || vehicle = "Motorcycles"
    not superCool

// Remove all the vehicles that are not 'super cool'.
allVehicles.RemoveWhere isNotSuperCool |> ignore

printfn "\nThe super cool vehicles are:\n"

for vehicle in allVehicles do
    printfn $"{vehicle}"

// The program writes the following output to the console.
//
// The current HashSet contains:
//
// Planes
// Trains
// Automobiles
//
// The updated HashSet contains:
//
// Planes
// Trains
// Automobiles
// Ships
// Motorcycles
// Rockets
// Helicopters
// Submarines
//
// The 'All' vehicles set contains everything in 'Some' vehicles list.
//
// The 'All' vehicles set contains 'roCKeTs'
//
// The excepted HashSet contains:
//
// Ships
// Motorcycles
// Rockets
// Helicopters
// Submarines
//
// The super cool vehicles are:
//
// Motorcycles
// Helicopters
//</snippet03>
