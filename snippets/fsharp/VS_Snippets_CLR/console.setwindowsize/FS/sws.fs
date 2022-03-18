//<snippet1>
// This example demonstrates the Console.SetWindowSize method,
//                           the Console.WindowWidth property,
//                       and the Console.WindowHeight property.
open System

//
// Step 1: Get the current window dimensions.
//
let origWidth  = Console.WindowWidth
let origHeight = Console.WindowHeight
printfn $"The current window width is {Console.WindowWidth}, and the current window height is {Console.WindowHeight}."
printfn "  (Press any key to continue...)"
Console.ReadKey true |> ignore

//
// Step 2: Cut the window to 1/4 its original size.
//
let width  = origWidth / 2
let height = origHeight / 2
Console.SetWindowSize(width, height)
printfn $"The new window width is {Console.WindowWidth}, and the new window height is {Console.WindowHeight}."
                        
printfn "  (Press any key to continue...)"
Console.ReadKey true |> ignore

//
// Step 3: Restore the window to its original size.
//
Console.SetWindowSize(origWidth, origHeight)
printfn $"The current window width is {Console.WindowWidth}, and the current window height is {Console.WindowHeight}."


// This example produces the following results:
//
// The current window width is 85, and the current window height is 43.
//   (Press any key to continue...)
// The new window width is 42, and the new window height is 21.
//   (Press any key to continue...)
// The current window width is 85, and the current window height is 43.
//</snippet1>