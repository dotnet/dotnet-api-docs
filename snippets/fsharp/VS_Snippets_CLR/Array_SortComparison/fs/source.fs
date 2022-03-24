// <Snippet1>
open System

let compareDinosByLength (x: string) (y: string) =
    match x with
    // If x is null and y is null, they're equal.
    | null when isNull y -> 0 
    // If x is null and y is not null, y is greater.
    | null -> -1
    // If x is not null and y is null, x is greater.
    | _ when isNull y -> 1    
    // If x is not null and y is not null, compare the lengths of the two strings.
    | _ ->
        let retval = x.Length.CompareTo y.Length
        if retval <> 0 then
            // If the strings are not of equal length, the longer string is greater.
            retval
        else
            // If the strings are of equal length, sort them with ordinary string comparison.
            x.CompareTo y

let display arr =
    printfn ""
    for s in arr do
        if isNull s then
            printfn "(null)"
        else
            printfn $"\"{s}\""

let dinosaurs =
    [| "Pachycephalosaurus"
       "Amargasaurus"
       ""
       null
       "Mamenchisaurus"
       "Deinonychus" |]
       
display dinosaurs

printfn "\nSort with generic Comparison<string> delegate:"
Array.Sort(dinosaurs, compareDinosByLength)
display dinosaurs

// This code example produces the following output:
//
//    "Pachycephalosaurus"
//    "Amargasaurus"
//    ""
//    (null)
//    "Mamenchisaurus"
//    "Deinonychus"
//    
//    Sort with generic Comparison<string> delegate:
//    
//    (null)
//    ""
//    "Deinonychus"
//    "Amargasaurus"
//    "Mamenchisaurus"
//    "Pachycephalosaurus"
//    
// </Snippet1>