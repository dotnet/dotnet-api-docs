module type_getmembers1

// <Snippet1>
type MyClass =
    val public myInt: int
    val public myString: string

    new () = { myInt = 0; myString = null}

    member _.MyMethod() = ()

try
    let myObject = MyClass()

    // Get the type of 'MyClass'.
    let myType = myObject.GetType()

    // Get the information related to all public member's of 'MyClass'.
    let myMemberInfo = myType.GetMembers()

    printfn $"\nThe members of class '{myType}' are :\n"
    for i = 0 to myMemberInfo.Length - 1 do
    // Display name and type of the concerned member.
        printfn $"'{myMemberInfo[i].Name}' is a {myMemberInfo[i].MemberType}"
with e ->
    printfn $"Exception : {e.Message}"
// </Snippet1>