// System.Int32.Equals(Object)

(*
   The following program demonstrates the 'Equals(Object)' method
   of struct 'Int32'. This compares an instance of 'Int32' with the
   passed in object and returns true if they are equal.
*)

open System

// <Snippet1>
let myVariable1 = 60
let myVariable2 = 60

// Get and display the declaring type.
printfn $"\nType of 'myVariable1' is '{myVariable1.GetType()}' and value is: {myVariable1}"
printfn $"Type of 'myVariable2' is '{myVariable2.GetType()}' and value is: {myVariable2}"

// Compare 'myVariable1' instance with 'myVariable2' Object.
if myVariable1.Equals myVariable2 then
    printfn "\nStructures 'myVariable1' and 'myVariable2' are equal"
else
    printfn "\nStructures 'myVariable1' and 'myVariable2' are not equal"

// </Snippet1>
        