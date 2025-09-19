module source1

// <Snippet1>
open System

printfn $"{Math.Round(3.44, 1)}" //Returns 3.4.
printfn $"{Math.Round(3.45, 1)}" //Returns 3.4.
printfn $"{Math.Round(3.46, 1)}" //Returns 3.5.

printfn $"{Math.Round(4.34, 1)}" // Returns 4.3
printfn $"{Math.Round(4.35, 1)}" // Returns 4.4
printfn $"{Math.Round(4.36, 1)}" // Returns 4.4
// </Snippet1>