//<Snippet1>
open System

// An enumeration of animals. Start at 1 (0 = uninitialized).
type Animal =
    | Dog = 1
    | Cat = 2
    | Bird = 3

// A custom attribute to allow a target to have a pet.
type AnimalTypeAttribute(pet) =
    inherit Attribute()
    member val Pet = pet with get, set

// A test class where each method has its own pet.
type AnimalTypeTestClass() =
    [<AnimalType(Animal.Dog)>]
    member _.DogMethod() = ()

    [<AnimalType(Animal.Cat)>]
    member _.CatMethod() = ()

    [<AnimalType(Animal.Bird)>]
    member _.BirdMethod() = ()

let testClass = AnimalTypeTestClass()
let clsType = testClass.GetType()
// Iterate through all the methods of the class.
for mInfo in clsType.GetMethods() do
    // Iterate through all the Attributes for each method.
    for attr in Attribute.GetCustomAttributes mInfo do
        // Check for the AnimalType attribute.
        if attr.GetType() = typeof<AnimalTypeAttribute> then
            printfn $"Method {mInfo.Name} has a pet {(attr :?> AnimalTypeAttribute).Pet} attribute."

// Output:
//   Method DogMethod has a pet Dog attribute.
//   Method CatMethod has a pet Cat attribute.
//   Method BirdMethod has a pet Bird attribute.

//</Snippet1>
