//<snippet1>
open System

// The Point class is derived from System.Object.
type Point(x, y) =
    member _.X = x
    member _.Y = y
    //<snippet2>
    override _.Equals obj =
        // If this and obj do not refer to the same type, then they are not equal.
        match obj with
        | :? Point as other ->
            // Return true if  x and y fields match.
            x = other.X &&  y = other.Y
        | _ -> 
            false
    //</snippet2>

    //<snippet3>
    // Return the XOR of the x and y fields.
    override _.GetHashCode() =
        x ^^^ y
    //</snippet3>

    //<snippet4>
    // Return the point's value as a string.
    override _.ToString() =
        $"({x}, {y})"
    //</snippet4>

    //<snippet5>
    // Return a copy of this point object by making a simple field copy.
    member this.Copy() =
        this.MemberwiseClone() :?> Point
    //</snippet5>

// Construct a Point object.
let p1 = Point(1,2)

// Make another Point object that is a copy of the first.
let p2 = p1.Copy()

// Make another variable that references the first Point object.
let p3 = p1

//<snippet6>
// The line below displays false because p1 and p2 refer to two different objects.
printfn $"{Object.ReferenceEquals(p1, p2)}"
//</snippet6>

//<snippet7>
// The line below displays true because p1 and p2 refer to two different objects that have the same value.
printfn $"{Object.Equals(p1, p2)}"
//</snippet7>

// The line below displays true because p1 and p3 refer to one object.
printfn $"{Object.ReferenceEquals(p1, p3)}"

//<snippet8>
// The line below displays: p1's value is: (1, 2)
printfn $"p1's value is: {p1.ToString()}"
//</snippet8>
// This code example produces the following output:
//
// False
// True
// True
// p1's value is: (1, 2)
//
//</snippet1>