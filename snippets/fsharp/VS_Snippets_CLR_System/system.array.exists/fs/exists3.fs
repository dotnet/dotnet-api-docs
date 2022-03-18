module exists3

// <Snippet3>
open System

let  planets = 
    [| "Mercury"; "Venus"
       "Earth"; "Mars"; "Jupiter"
       "Saturn"; "Uranus"; "Neptune" |]

Array.Exists(planets, fun element -> element.StartsWith "M")
|> printfn "One or more planets begin with 'M': %O"

Array.Exists(planets, fun element -> element.StartsWith "T")
|> printfn "One or more planets begin with 'T': %O"

Array.Exists(planets, fun element -> element = "Pluto")
|> printfn "Is Pluto one of the planets? %O"

// The example displays the following output:
//       One or more planets begin with 'M': True
//       One or more planets begin with 'T': False
//       Is Pluto one of the planets? False
// </Snippet3>