// <Snippet1>
open System
open System.Collections.Generic

// <Snippet8>
type Box(h, l, w) =
    member val Height: int = h with get
    member val Length: int = l with get
    member val Width: int = w with get

    interface IComparable<Box> with
        member this.CompareTo(other) =
            // Compares Height, Length, and Width.
            if this.Height.CompareTo other.Height <> 0 then
                this.Height.CompareTo other.Height
            elif this.Length.CompareTo other.Length <> 0 then
                this.Length.CompareTo other.Length
            elif this.Width.CompareTo other.Width <> 0 then
                this.Width.CompareTo other.Width
            else
                0
// </Snippet8>

// <Snippet5>
type BoxLengthFirst() =
    inherit Comparer<Box>()

    // <Snippet6>
    // Compares by Length, Height, and Width.
    override _.Compare(x: Box, y: Box) =
        if x.Length.CompareTo y.Length <> 0 then
            x.Length.CompareTo y.Length
        elif x.Height.CompareTo y.Height <> 0 then
            x.Height.CompareTo y.Height
        elif x.Width.CompareTo y.Width <> 0 then
            x.Width.CompareTo y.Width
        else
            0
// </Snippet6>
// </Snippet5>

// <Snippet2>
let boxes = ResizeArray<Box>()
boxes.Add(Box(4, 20, 14))
boxes.Add(Box(12, 12, 12))
boxes.Add(Box(8, 20, 10))
boxes.Add(Box(6, 10, 2))
boxes.Add(Box(2, 8, 4))
boxes.Add(Box(2, 6, 8))
boxes.Add(Box(4, 12, 20))
boxes.Add(Box(18, 10, 4))
boxes.Add(Box(24, 4, 18))
boxes.Add(Box(10, 4, 16))
boxes.Add(Box(10, 2, 10))
boxes.Add(Box(6, 18, 2))
boxes.Add(Box(8, 12, 4))
boxes.Add(Box(12, 10, 8))
boxes.Add(Box(14, 6, 6))
boxes.Add(Box(16, 6, 16))
boxes.Add(Box(2, 8, 12))
boxes.Add(Box(4, 24, 8))
boxes.Add(Box(8, 6, 20))
boxes.Add(Box(18, 18, 12))

// Sort by an Comparer<T> implementation that sorts
// first by the length.
boxes.Sort(BoxLengthFirst())

printfn "H - L - W"
printfn "=========="

for bx in boxes do
    printfn $"{bx.Height}\t{bx.Length}\t{bx.Width}"
// </Snippet2>

printfn ""
printfn "H - L - W"
printfn "=========="

// <Snippet3>
// Get the default comparer that
// sorts first by the height.
let defComp = Comparer<Box>.Default

// Calling Boxes.Sort() with no parameter
// is the same as calling boxes.Sort defComp
// because they are both using the default comparer.
boxes.Sort()

for bx in boxes do
    printfn $"{bx.Height}\t{bx.Length}\t{bx.Width}"
// </Snippet3>

// <Snippet4>

// This explicit interface implementation
// compares first by the length.
// Returns -1 because the length of BoxA
// is less than the length of BoxB.
let LengthFirst = BoxLengthFirst()

let bc = LengthFirst :> Comparer<Box>

let BoxA = Box(2, 6, 8)
let BoxB = Box(10, 12, 14)
let x = LengthFirst.Compare(BoxA, BoxB)
printfn $"\n{x}"
// </Snippet4>

// <Snippet7>
// This class is not demonstrated in the Main method
// and is provided only to show how to implement
// the interface. It is recommended to derive
// from Comparer<T> instead of implementing IComparer<T>.
type BoxComp() =
    interface IComparer<Box> with
        // Compares by Height, Length, and Width.
        member _.Compare(x: Box, y: Box) =
            if x.Height.CompareTo(y.Height) <> 0 then
                x.Height.CompareTo(y.Height)
            elif x.Length.CompareTo(y.Length) <> 0 then
                x.Length.CompareTo(y.Length)
            elif x.Width.CompareTo(y.Width) <> 0 then
                x.Width.CompareTo(y.Width)
            else
                0
// </Snippet7>

// </Snippet1>
