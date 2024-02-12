// <Snippet1>
// <Snippet2>
open System.Reflection

type MyFieldClassA =
    val public Field: string
    new () = { Field = "A Field"}

type MyFieldClassB() =
    let field = "B Field"
    member _.Field
        with get () = field

let myFieldObjectB = MyFieldClassB()
let myFieldObjectA = MyFieldClassA()

let myTypeA = typeof<MyFieldClassA>
let myFieldInfo = myTypeA.GetField "Field"

let myTypeB = typeof<MyFieldClassB>
let myFieldInfo1 = myTypeB.GetField("field", BindingFlags.NonPublic ||| BindingFlags.Instance)

printfn $"The value of the public field is: '{myFieldInfo.GetValue myFieldObjectA}'"
printfn $"The value of the private field is: '{myFieldInfo1.GetValue myFieldObjectB}'"
// </Snippet2>
// </Snippet1>