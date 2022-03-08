module nullreturn2

// <Snippet4>
open System

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

printfn $"{found.FirstName}"

// The example displays the following output:
//       Unhandled Exception: System.NullReferenceException:
//       Object reference not set to an instance of an object.
//          at <StartupCode$fs>.main()
// </Snippet4>