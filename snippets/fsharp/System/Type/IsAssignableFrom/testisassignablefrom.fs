module testisassignablefrom

//<Snippet1>
open System

type Room() = class end

type Kitchen() = inherit Room()

type Bedroom() = inherit Room()

type Guestroom() = inherit Bedroom()

type MasterBedroom() = inherit Bedroom()

// Demonstrate classes:
printfn "Defined Classes:"
let room1 = Room()
let kitchen1 = Kitchen()
let bedroom1 = Bedroom()
let guestroom1 = Guestroom()
let masterbedroom1 = MasterBedroom()

let room1Type = room1.GetType()
let kitchen1Type = kitchen1.GetType()
let bedroom1Type = bedroom1.GetType()
let guestroom1Type = guestroom1.GetType()
let masterbedroom1Type = masterbedroom1.GetType()

printfn $"room assignable from kitchen: {room1Type.IsAssignableFrom kitchen1Type}"
printfn $"bedroom assignable from guestroom: {bedroom1Type.IsAssignableFrom guestroom1Type}"
printfn $"kitchen assignable from masterbedroom: {kitchen1Type.IsAssignableFrom masterbedroom1Type}"

// Demonstrate arrays:
printfn "\nInteger arrays:"

let array2 = Array.zeroCreate<int> 2
let array10 = Array.zeroCreate<int> 10
let array22 = Array2D.zeroCreate<int> 2 2
let array24 = Array2D.zeroCreate<int> 2 4

let array2Type = array2.GetType()
let array10Type = array10.GetType()
let array22Type = array22.GetType()
let array24Type = array24.GetType()

printfn $"int[2] assignable from int[10]: {array2Type.IsAssignableFrom array10Type}"
printfn $"int[2] assignable from int[2,4]: {array2Type.IsAssignableFrom array24Type}"
printfn $"int[2,4] assignable from int[2,2]: {array24Type.IsAssignableFrom array22Type}"

// Demonstrate generics:
printfn "\nGenerics:"

let arrayNull = Array.zeroCreate<Nullable<int>> 10
let genIntList = ResizeArray<int>()
let genTList = ResizeArray<Type>()

let arrayNullType = arrayNull.GetType()
let genIntListType = genIntList.GetType()
let genTListType = genTList.GetType()

printfn $"int[10] assignable from int?[10]: {array10Type.IsAssignableFrom arrayNullType}"
printfn $"List<int> assignable from List<Type>: {genIntListType.IsAssignableFrom genTListType}"
printfn $"List<Type> assignable from List<int>: {genTListType.IsAssignableFrom genIntListType}"

//This code example produces the following output:
//
// Defined Classes:
// room assignable from kitchen: True
// bedroom assignable from guestroom: True
// kitchen assignable from masterbedroom: False
//
// Integer arrays:
// int[2] assignable from int[10]: True
// int[2] assignable from int[2,4]: False
// int[2,4] assignable from int[2,2]: True
//
// Generics:
// int[10] assignable from int?[10]: False
// List<int> assignable from List<Type>: False
// List<Type> assignable from List<int>: False
//</Snippet1>