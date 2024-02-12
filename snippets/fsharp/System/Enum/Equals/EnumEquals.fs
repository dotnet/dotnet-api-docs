module EnumEquals

//<snippet1>
open System

type Colors =
    | Red = 0
    | Green = 1
    | Blue = 2
    | Yellow = 3

type Mammals =
    | Cat = 0
    | Dog = 1
    | Horse = 2
    | Dolphin = 3

let myPet = Mammals.Cat
let myColor = Colors.Red
let yourPet = Mammals.Dog
let yourColor = Colors.Red

printfn 
    $"""My favorite animal is a {myPet}
Your favorite animal is a {yourPet}
Do we like the same animal? {if myPet.Equals yourPet then "Yes" else "No"}

My favorite color is {myColor}
Your favorite color is {yourColor}
Do we like the same color? {if myColor.Equals yourColor then "Yes" else "No"}

The value of my color ({myColor}) is {Enum.Format(typeof<Colors>, myColor, "d")}
The value of my pet (a {myPet}) is {Enum.Format(typeof<Mammals>, myPet, "d")}
Even though they have the same value, are they equal? {if myColor.Equals myPet then "Yes" else "No"}"""

// The example displays the following output:
//    My favorite animal is a Cat
//    Your favorite animal is a Dog
//    Do we like the same animal? No
//
//    My favorite color is Red
//    Your favorite color is Red
//    Do we like the same color? Yes
//
//    The value of my color (Red) is 0
//    The value of my pet (a Cat) is 0
//    Even though they have the same value, are they equal? No
//</snippet1>