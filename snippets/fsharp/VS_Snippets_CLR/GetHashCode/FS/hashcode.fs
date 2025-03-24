// <Snippet1>
open System
open System.Reflection
open System.Collections.Generic

// A custom attribute to allow two authors per method.
[<AllowNullLiteral>]
type AuthorsAttribute(authorName1, authorName2) =
    inherit Attribute()

    member val AuthorName1 = authorName1
    member val AuthorName2 = authorName2

    // Use the hash code of the string objects and xor them together.
    override _.GetHashCode() =
        authorName1.GetHashCode() ^^^ authorName2.GetHashCode()

// Provide the author names for each method of the class.
type TestClass() =
    [<Authors("Immanuel Kant", "Lao Tzu")>]
    member _.Method1() = ()

    [<Authors("Jean-Paul Sartre", "Friedrich Nietzsche")>]
    member _.Method2() = ()

    [<Authors("Immanuel Kant", "Lao Tzu")>]
    member _.Method3() = ()

    [<Authors("Jean-Paul Sartre", "Friedrich Nietzsche")>]
    member _.Method4() = ()

    [<Authors("Immanuel Kant", "Friedrich Nietzsche")>]
    member _.Method5() = ()

// Get the class type to access its metadata.
let clsType = typeof<TestClass>

// Store author information in a array of tuples.
let authorsInfo = 
  [ // Iterate through all the methods of the class.
    for method in clsType.GetMethods() do
        // Get the Authors attribute for the method if it exists.
        let authAttr =
            Attribute.GetCustomAttribute(method, typeof<AuthorsAttribute>) :?> AuthorsAttribute

        if authAttr <> null then
            // Add the information to the author list.
            $"{clsType.Name}.{method.Name}", authAttr ]

// Iterate through the list
printfn "Method authors:\n"

authorsInfo
|> List.groupBy (fun (_, authors) -> authors.AuthorName1, authors.AuthorName2)
|> List.iter (fun ((name1, name2), authors) ->
    printfn $"{name1} and {name2}"
    for (methodName, _) in authors do
        printfn $"   {methodName}")

// The example displays the following output:
//       Method authors:
//
//       Immanuel Kant and Lao Tzu
//          TestClass.Method1
//          TestClass.Method3
//       Jean-Paul Sartre and Friedrich Nietzsche
//          TestClass.Method2
//          TestClass.Method4
//       Immanuel Kant and Friedrich Nietzsche
//          TestClass.Method5
// </Snippet1>
