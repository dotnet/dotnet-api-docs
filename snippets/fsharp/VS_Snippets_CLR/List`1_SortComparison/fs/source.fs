// <Snippet1>
open System

let compareDinosByLength (x: string) (y: string) =
    match x with 
    | null when isNull y ->
        // If x is null and y is null, they're equal.
        0
    | null ->
        // If x is null and y is not null, y is greater.
        -1
    | _ when isNull y->
        // If x is not null and y is null, x is greater.
        1
    | _ ->
        // If x is not null and y is not null, compare the lengths of the two strings.
        let retval = x.Length.CompareTo y.Length

        if retval <> 0 then
            // If the strings are not of equal length, the longer string is greater.
            retval
        else
            // If the strings are of equal length, sort them with ordinary string comparison.
            x.CompareTo y

let display list =
    printfn ""
    for s in list do
        if isNull s then
            printfn "(null)"
        else
            printfn $"\"%s{s}\""


let dinosaurs = ResizeArray()
dinosaurs.Add "Pachycephalosaurus"
dinosaurs.Add "Amargasaurus"
dinosaurs.Add ""
dinosaurs.Add null
dinosaurs.Add "Mamenchisaurus"
dinosaurs.Add "Deinonychus"
display dinosaurs

printfn "\nSort with generic Comparison<string> delegate:"
dinosaurs.Sort compareDinosByLength
display dinosaurs


// This code example produces the following output:
//
// "Pachycephalosaurus"
// "Amargasaurus"
// ""
// (null)
// "Mamenchisaurus"
// "Deinonychus"
//
// Sort with generic Comparison<string> delegate:
//
// (null)
// ""
// "Deinonychus"
// "Amargasaurus"
// "Mamenchisaurus"
// "Pachycephalosaurus"
// </Snippet1>