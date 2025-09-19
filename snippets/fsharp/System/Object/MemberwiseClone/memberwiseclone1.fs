// <Snippet1>
open System

type IdInfo(IdNumber) =
    member val IdNumber = IdNumber with get, set

type Person() =
    [<DefaultValue>]
    val mutable public Age: int
    [<DefaultValue>]
    val mutable public Name: string
    [<DefaultValue>]
    val mutable public IdInfo: IdInfo

    member this.ShallowCopy() =
        this.MemberwiseClone() :?> Person

    member this.DeepCopy() =
       let other = this.MemberwiseClone() :?> Person
       other.IdInfo <- IdInfo this.IdInfo.IdNumber
       other

let displayValues (p: Person) =
    printfn $"      Name: {p.Name:s}, Age: {p.Age:d}"
    printfn $"      Value: {p.IdInfo.IdNumber:d}"

// Create an instance of Person and assign values to its fields.
let p1 = Person()
p1.Age <- 42
p1.Name <- "Sam"
p1.IdInfo <- IdInfo 6565

// Perform a shallow copy of p1 and assign it to p2.
let p2 = p1.ShallowCopy()

// Display values of p1, p2
printfn "Original values of p1 and p2:"
printfn "   p1 instance values: "
displayValues p1
printfn "   p2 instance values:"
displayValues p2

// Change the value of p1 properties and display the values of p1 and p2.
p1.Age <- 32
p1.Name <- "Frank"
p1.IdInfo.IdNumber <- 7878
printfn "\nValues of p1 and p2 after changes to p1:"
printfn "   p1 instance values: "
displayValues p1
printfn "   p2 instance values:"
displayValues p2

// Make a deep copy of p1 and assign it to p3.
let p3 = p1.DeepCopy()
// Change the members of the p1 class to new values to show the deep copy.
p1.Age <- 39
p1.Name <- "George"
p1.IdInfo.IdNumber <- 8641
printfn "\nValues of p1 and p3 after changes to p1:"
printfn "   p1 instance values: "
displayValues p1
printfn "   p3 instance values:"
displayValues p3

// The example displays the following output:
//       Original values of p1 and p2:
//          p1 instance values:
//             Name: Sam, Age: 42
//             Value: 6565
//          p2 instance values:
//             Name: Sam, Age: 42
//             Value: 6565
//
//       Values of p1 and p2 after changes to p1:
//          p1 instance values:
//             Name: Frank, Age: 32
//             Value: 7878
//          p2 instance values:
//             Name: Sam, Age: 42
//             Value: 7878
//
//       Values of p1 and p3 after changes to p1:
//          p1 instance values:
//             Name: George, Age: 39
//             Value: 8641
//          p3 instance values:
//             Name: Frank, Age: 32
//             Value: 7878
// </Snippet1>
