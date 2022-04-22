module type_getmembers2

// <Snippet1>
open System.Reflection
open System.Security

type MyClass =
    val public myInt: int
    val public myString: string

    new () = { myInt = 0; myString = null}

    member _.MyMethod() = ()

try
    let MyObject = MyClass()

    // Get the type of the class 'MyClass'.
    let myType = MyObject.GetType()

    // Get the public instance members of the class 'MyClass'.
    let myMemberInfo = myType.GetMembers(BindingFlags.Public ||| BindingFlags.Instance)

    printfn $"\nThe public instance members of class '{myType}' are : \n"
    for i = 0 to myMemberInfo.Length - 1 do
        // Display name and type of the member of 'MyClass'.
        printfn $"'{myMemberInfo[i].Name}' is a {myMemberInfo[i].MemberType}"
with :? SecurityException as e ->
    printfn $"SecurityException : {e.Message}"

//Output:
//The public instance members of class 'MyClass' are :

//'Myfunction' is a Method
//'ToString' is a Method
//'Equals' is a Method
//'GetHashCode' is a Method
//'GetType' is a Method
//'.ctor' is a Constructor
//'myInt' is a Field
//'myString' is a Field
// </Snippet1>
