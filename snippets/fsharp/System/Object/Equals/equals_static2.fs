module equals_static2

// <Snippet1>
open System

// Class constructor
type Dog(dogBreed) =
    // Public property.
    member _.Breed = dogBreed

    override this.Equals(obj) =
        match obj with
        | :? Dog as dog when dog.Breed = this.Breed -> true
        | _ -> false

    override _.GetHashCode() =
        dogBreed.GetHashCode()

    override _.ToString() =
        dogBreed

let m1 = Dog "Alaskan Malamute"
let m2 = Dog "Alaskan Malamute"
let g1 = Dog "Great Pyrenees"
let g2 = g1
let d1 = Dog "Dalmation"
let n1 = Unchecked.defaultof<Dog>
let n2 = Unchecked.defaultof<Dog>

printfn $"null = null: {Object.Equals(n1, n2)}"
printfn $"null Reference Equals null: {Object.ReferenceEquals(n1, n2)}\n"

printfn $"{g1} = {g2}: {Object.Equals(g1, g2)}"
printfn $"{g1} Reference Equals {g2}: {Object.ReferenceEquals(g1, g2)}\n"

printfn $"{m1} = {m2}: {Object.Equals(m1, m2)}"
printfn $"{m1} Reference Equals {m2}: {Object.ReferenceEquals(m1, m2)}\n"

printfn $"{m1} = {d1}: {Object.Equals(m1, d1)}"
printfn $"{m1} Reference Equals {d1}: {Object.ReferenceEquals(m1, d1)}"

// The example displays the following output:
//       null = null: True
//       null Reference Equals null: True
//
//       Great Pyrenees = Great Pyrenees: True
//       Great Pyrenees Reference Equals Great Pyrenees: True
//
//       Alaskan Malamute = Alaskan Malamute: True
//       Alaskan Malamute Reference Equals Alaskan Malamute: False
//
//       Alaskan Malamute = Dalmation: False
//       Alaskan Malamute Reference Equals Dalmation: False
// </Snippet1>