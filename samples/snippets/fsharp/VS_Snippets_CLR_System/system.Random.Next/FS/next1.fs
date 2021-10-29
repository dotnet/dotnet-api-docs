open System

// <Snippet3>
let rnd = Random()

let malePetNames =
    [| "Rufus"; "Bear"; "Dakota"; "Fido";
        "Vanya"; "Samuel"; "Koani"; "Volodya";
        "Prince"; "Yiska" |]
let femalePetNames = 
    [| "Maggie"; "Penny"; "Saya"; "Princess";
        "Abby"; "Laila"; "Sadie"; "Olivia";
        "Starlight"; "Talla" |]

// Generate random indexes for pet names.
let mIndex = rnd.Next malePetNames.Length
let fIndex = rnd.Next femalePetNames.Length

// Display the result.
printfn "Suggested pet name of the day: "
printfn "   For a male:     %s" malePetNames.[mIndex]
printfn "   For a female:   %s" femalePetNames.[fIndex]

// The example displays output similar to the following:
//       Suggested pet name of the day:
//          For a male:     Koani
//          For a female:   Maggie
// </Snippet3>
