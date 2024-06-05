module exists2

// <Snippet2>
open System

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
    let exists = 
        Array.Exists(names, fun s -> 
            if String.IsNullOrEmpty s then false 
            else s.Substring(0, 1).ToUpper() = string char)

    printfn $"One or more names begin with '{char}': {exists}"
                    
// The example displays the following output:
//       One or more names begin with 'A': True
//       One or more names begin with 'K': False
//       One or more names begin with 'W': True
//       One or more names begin with 'Z': False
// </Snippet2>
