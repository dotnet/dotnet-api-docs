module source

// <Snippet1>
type Colors =
    | Red = 1
    | Blue = 2

let myColors = Colors.Red
printfn $"The value of this instance is '{myColors.ToString()}'"

// Output.
// The value of this instance is 'Red'.
// </Snippet1>