// <Snippet1>
open System.Runtime.InteropServices

// The Demo class is attributed as AutoLayout.
[<StructLayoutAttribute(LayoutKind.Auto)>]
type Demo = class end

// Create an instance of the Type class using the GetType method.
let myType = typeof<Demo>
// Get and display the IsAutoLayout property of the
// Demoinstance.
printfn $"\nThe AutoLayout property for the Demo class is {myType.IsAutoLayout}."
// </Snippet1>