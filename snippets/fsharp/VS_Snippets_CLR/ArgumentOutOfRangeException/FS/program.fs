// <Snippet1>
open System

type Guest(fName: string, lName: string, age: int) =
    let minimumRequiredAge = 21

    do if age < minimumRequiredAge then 
        raise (ArgumentOutOfRangeException(nameof age, $"All guests must be {minimumRequiredAge}-years-old or older."))

    member _.FirstName = fName
    member _.LastName = lName
    member _.GuestInfo() = $"{fName} {lName}, {age}"

try
    let guest1 = Guest("Ben", "Miller", 17);
    printfn $"{guest1.GuestInfo()}"
with
| :? ArgumentOutOfRangeException as e ->
    printfn $"Error: {e.Message}"
// </Snippet1>