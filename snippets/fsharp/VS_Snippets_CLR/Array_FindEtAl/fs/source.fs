// <Snippet1>
open System

// Search predicate returns true if a string ends in "saurus".
let endsWithSaurus (s: string) =
    s.Length > 5 && s.Substring(s.Length - 6).ToLower() = "saurus"

// Search predicate returns true if a string ends in "raptor".
let endsWithRaptor (s: string) =
    s.Length > 5 && s.Substring(s.Length - 6).ToLower() = "raptor"

// Search predicate returns true if a string ends in "tops".
let endsWithTops (s: string) =
    s.Length > 3 && s.Substring(s.Length - 4).ToLower() = "tops"

type DinoDiscoverySet =
    { Dinosaurs: string [] }

    member this.DiscoverAll() =
        printfn ""
        for dino in this.Dinosaurs do
            printfn $"{dino}"

    member this.DiscoverByEnding(ending: string) =
        let dinoType =
            match ending.ToLower() with
            | "raptor" -> endsWithRaptor
            | "tops" -> endsWithTops
            | "saurus" | _ -> endsWithSaurus

        Array.Exists(this.Dinosaurs, dinoType)
        |> printfn "\nArray.Exists(dinosaurs, \"%s\"): %b" ending

        Array.TrueForAll(this.Dinosaurs, dinoType)
        |> printfn "\nArray.TrueForAll(dinosaurs, \"%s\"): %b" ending

        Array.Find(this.Dinosaurs, dinoType)
        |> printfn "\nArray.Find(dinosaurs, \"%s\"): %s" ending

        Array.FindLast(this.Dinosaurs, dinoType)
        |> printfn "\nArray.FindLast(dinosaurs, \"%s\"): %s" ending

        printfn $"\nArray.FindAll(dinosaurs, \"{ending}\"):"
        for dinosaur in Array.FindAll(this.Dinosaurs, dinoType) do
            printfn $"{dinosaur}"

let dinosaurs =
    [| "Compsognathus"; "Amargasaurus"; "Oviraptor"
       "Velociraptor"; "Deinonychus"; "Dilophosaurus"
       "Gallimimus"; "Triceratops" |]

let goMesozoic = { Dinosaurs = dinosaurs }

goMesozoic.DiscoverAll()
goMesozoic.DiscoverByEnding "saurus"


// This code example produces the following output:
//     Compsognathus
//     Amargasaurus
//     Oviraptor
//     Velociraptor
//     Deinonychus
//     Dilophosaurus
//     Gallimimus
//     Triceratops
//
//     Array.Exists(dinosaurs, "saurus"): true
//
//     Array.TrueForAll(dinosaurs, "saurus"): false
//
//     Array.Find(dinosaurs, "saurus"): Amargasaurus
//
//     Array.FindLast(dinosaurs, "saurus"): Dilophosaurus
//
//     Array.FindAll(dinosaurs, "saurus"):
//     Amargasaurus
//     Dilophosaurus
// </Snippet1>
