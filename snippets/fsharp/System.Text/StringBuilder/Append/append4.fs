module append4
// <Snippet18>
open System.Text

type Dog(name: string, breed: string) =
    member _.Name = name
    member _.Breed = breed
    override _.ToString() = name

let dog1 = Dog("Yiska", "Alaskan Malamute")
let sb = StringBuilder()
sb.Append(dog1).Append(", Breed: ").Append dog1.Breed |> printfn "%O"

// The example displays the following output:
//        Yiska, Breed: Alaskan Malamute
// </Snippet18>
