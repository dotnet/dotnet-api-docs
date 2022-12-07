//<Snippet1>
open System
open System.Reflection

type AttributesSample() =
    member _.Mymethod(int1m: int, str2m: string outref, str3m: string byref) =
        str2m <- "in Mymethod"

let printAttributes (attribType: Type) iAttribValue =
    if not attribType.IsEnum then
        printfn "This type is not an enum."
    else
        let fields = attribType.GetFields(BindingFlags.Public ||| BindingFlags.Static)
        for f in fields do
            let fieldvalue = f.GetValue null :?> int
            if fieldvalue &&& iAttribValue = fieldvalue then
                printfn $"{f.Name}"

printfn "Reflection.MethodBase.Attributes Sample"

// Get the type.
let MyType = Type.GetType "AttributesSample"

// Get the method Mymethod on the type.
let Mymethodbase = MyType.GetMethod "Mymethod"

// Display the method name.
printfn $"Mymethodbase = {Mymethodbase}"

// Get the MethodAttribute enumerated value.
let Myattributes = Mymethodbase.Attributes

// Display the flags that are set.
printAttributes typeof<MethodAttributes> (int Myattributes)
//</Snippet1>