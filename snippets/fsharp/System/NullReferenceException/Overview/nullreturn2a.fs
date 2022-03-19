module nullreturn2a

// <Snippet5>
open System

[<AllowNullLiteral>]
type Person(firstName) =
    member _.FirstName = firstName

    static member AddRange(firstNames) =
        Array.map Person firstNames

let persons = 
    [| "Abigail"; "Abra"; "Abraham"; "Adrian"
       "Ariella"; "Arnold"; "Aston"; "Astor" |]
    |> Person.AddRange

let nameToFind = "Robert"
let found = Array.Find(persons, fun p -> p.FirstName = nameToFind)

if found <> null then
    printfn $"{found.FirstName}"
else 
    printfn $"{nameToFind} not found."

// Using F#'s Array.tryFind function
// This does not require a null check or [<AllowNullLiteral>]
let found2 = 
    persons |> Array.tryFind (fun p -> p.FirstName = nameToFind)

match found2 with
| Some firstName ->
    printfn $"{firstName}"
| None ->
    printfn $"{nameToFind} not found."

// The example displays the following output:
//        Robert not found.
//        Robert not found.
// </Snippet5>