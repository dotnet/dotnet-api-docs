module hasflag0

// <Snippet1>
open System

[<Flags>] 
type Pets =
    | None = 0
    | Dog = 1
    | Cat = 2
    | Bird = 4
    | Rabbit = 8
    | Other = 16

let petsInFamilies = [| Pets.None; Pets.Dog ||| Pets.Cat; Pets.Dog |]
let mutable familiesWithoutPets = 0
let mutable familiesWithDog = 0

for petsInFamily in petsInFamilies do
    // Count families that have no pets.
    if petsInFamily.Equals Pets.None then
        familiesWithoutPets <- familiesWithoutPets + 1
    // Of families with pets, count families that have a dog.
    elif petsInFamily.HasFlag Pets.Dog then
        familiesWithDog <- familiesWithDog + 1

printfn $"{familiesWithoutPets} of {petsInFamilies.Length} families in the sample have no pets."
printfn $"{familiesWithDog} of {petsInFamilies} families in the sample have a dog."
// The example displays the following output:
//       1 of 3 families in the sample have no pets.
//       2 of 3 families in the sample have a dog.
// </Snippet1>