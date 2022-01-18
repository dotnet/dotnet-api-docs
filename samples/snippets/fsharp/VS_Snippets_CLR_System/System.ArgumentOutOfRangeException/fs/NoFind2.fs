module NoFind2

// <Snippet18>
open System

let getSecondWord (s: string) =
    let pos = s.IndexOf " "
    if pos >= 0 then
        s.Substring(pos).Trim()
    else 
        String.Empty

let phrases = [ "ocean blue"; "concerned citizen"; "runOnPhrase" ]
for phrase in phrases do
    let word = getSecondWord phrase
    if not (String.IsNullOrEmpty word) then
        printfn $"Second word is {word}"

// The example displays the following output:
//       Second word is blue
//       Second word is citizen
// </Snippet18>
