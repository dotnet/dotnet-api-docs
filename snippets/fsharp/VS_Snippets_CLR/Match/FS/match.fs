open System

// A custom attribute to allow multiple authors per method.
[<AttributeUsage(AttributeTargets.Method); AllowNullLiteral>]
type AuthorsAttribute([<ParamArray>] names: string []) =
    inherit Attribute()

    member val Authors = ResizeArray names

    // Determine if the object is a match to this one.
    override this.Match(obj) =
        match obj with 
        | :? AuthorsAttribute as authors2 ->
            // Return true if obj and this instance are the same object reference.
            if Object.ReferenceEquals(this, authors2) then true
            // Return false if obj and this instance have different numbers of authors
            elif this.Authors.Count <> authors2.Authors.Count then false 
            else
                let authors1 = this.Authors |> set
                let authors2 = this.Authors |> set
                authors1 = authors2
        | _ ->
            // Return false if obj is null or not an AuthorsAttribute.
            false

    override this.ToString() =
        let retval = String.Join(", ", this.Authors)
        if retval.Trim().Length = 0 then 
            "<unknown>" 
        else 
            retval

// Add some authors to methods of a class.
type TestClass() =
    [<Authors("Leo Tolstoy", "John Milton")>]
    member _.Method1() = ()

    [<Authors "Anonymous">]
    member _.Method2() = ()

    [<Authors("Leo Tolstoy", "John Milton", "Nathaniel Hawthorne")>]
    member _.Method3() = ()

    [<Authors("John Milton", "Leo Tolstoy")>]
    member _.Method4() = ()

// Get the type for TestClass to access its metadata.
let clsType = typeof<TestClass>

// Iterate through each method of the class.

let mutable authors = null
for method in clsType.GetMethods() do
    // Check each method for the Authors attribute.
    let authAttr = 
        Attribute.GetCustomAttribute(method, typeof<AuthorsAttribute>)
        :?> AuthorsAttribute

    if authAttr <> null then
        // Display the authors.
        printfn $"{clsType.Name}.{method.Name} was authored by {authAttr}."

        // Select Method1's authors as the basis for comparison.
        if method.Name = "Method1" then
            authors <- authAttr
            printfn ""

        else
            // Compare first authors with the authors of this method.
            if authors.Match authAttr then
                printfn "TestClass.Method1 was also authored by the same team."

            // Perform an equality comparison of the two attributes.
            printfn $"""{authors} {if authors.Equals(authAttr) then "=" else "<>"} {authAttr}"""
            printfn ""

// The example displays the following output:
//       TestClass.Method1 was authored by Leo Tolstoy, John Milton.
//
//       TestClass.Method2 was authored by Anonymous.
//       Leo Tolstoy, John Milton <> Anonymous
//
//       TestClass.Method3 was authored by Leo Tolstoy, John Milton, Nathaniel Hawthorne.
//       Leo Tolstoy, John Milton <> Leo Tolstoy, John Milton, Nathaniel Hawthorne
//
//       TestClass.Method4 was authored by John Milton, Leo Tolstoy.
//       TestClass.Method1 was also authored by the same team.
//       Leo Tolstoy, John Milton <> John Milton, Leo Tolstoy