// <Snippet1>
let myVariable1 = 80L
let myVariable2 = 80L

// Get and display the declaring type.
printfn $"\nType of 'myVariable1' is '{myVariable1.GetType()}' and value is: {myVariable1}"
printfn $"\nType of 'myVariable2' is '{myVariable2.GetType()}' and value is: {myVariable2}"

// Compare 'myVariable1' instance with 'myVariable2' Object.
if myVariable1.Equals myVariable2 then
    printfn "\nStructures 'myVariable1' and 'myVariable2' are equal"
else
    printfn "\nStructures 'myVariable1' and 'myVariable2' are not equal"

// </Snippet1>