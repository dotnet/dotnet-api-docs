module exists1

// <Snippet1>
open System

type StringSearcher(firstChar) =
    member _.StartsWith(s) =
        if String.IsNullOrEmpty s then 
            false 
        else
            s.Substring(0, 1).ToUpper() = string firstChar

let names = 
    [| "Adam"; "Adel"; "Bridgette"; "Carla";
       "Charles"; "Daniel"; "Elaine"; "Frances"
       "George"; "Gillian"; "Henry"; "Irving"
       "James"; "Janae"; "Lawrence"; "Miguel"
       "Nicole"; "Oliver"; "Paula"; "Robert"
       "Stephen"; "Thomas"; "Vanessa"
       "Veronica"; "Wilberforce" |]

let charsToFind = [ 'A'; 'K'; 'W'; 'Z' ]

for char in charsToFind do 
    let exists = Array.Exists(names, fun x -> StringSearcher(char).StartsWith x)
    // let exists = Array.exists (StringSearcher(char).StartsWith) names
    printfn $"One or more names begin with '{char}': {exists}"

// The example displays the following output:
//       One or more names begin with 'A': True
//       One or more names begin with 'K': False
//       One or more names begin with 'W': True
//       One or more names begin with 'Z': False
// </Snippet1>
