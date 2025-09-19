// <Snippet1>
open System

// An enumeration of animals. Start at 1 (0 = uninitialized).
type Animal =
    | Dog = 1
    | Cat = 2
    | Bird = 3

// A custom attribute to allow a target to have a pet.
type AnimalTypeAttribute(pet) =
    inherit Attribute()

    member val Pet = pet

    // Override IsDefaultAttribute to return the correct response.
    override _.IsDefaultAttribute() =
        pet = Animal.Dog

    // Provide a default constructor and make Dog the default.
    new() = AnimalTypeAttribute Animal.Dog

type TestClass() =
    // Use the default constructor.
    [<AnimalType>]
    member _.Method1() = ()

// Get the class type to access its metadata.
let clsType = typeof<TestClass>

// Get type information for the method.
let mInfo = clsType.GetMethod "Method1"

// Get the AnimalType attribute for the method.
let atAttr = 
    Attribute.GetCustomAttribute(mInfo, typeof<AnimalTypeAttribute>) 
    :?> AnimalTypeAttribute

// Check to see if the default attribute is applied.
printf $"The attribute {atAttr.Pet} for method {mInfo.Name} in class {clsType.Name} "
printfn $"""{if atAttr.IsDefaultAttribute() then "is" else "is not"} the default for the AnimalType attribute."""

// Output:
//     The attribute Dog for method Method1 in class TestClass is the default for the AnimalType attribute.

// </Snippet1>
