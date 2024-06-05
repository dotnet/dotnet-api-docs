module fullnameex1

// <Snippet2>
// ResizeArray<'T> is an F# type abbreviation for System.Collection.Generic.List<'T>
open System

let t = typeof<ResizeArray<_>>.GetGenericTypeDefinition()
printfn $"{t.FullName}"
Console.WriteLine()

let list = ResizeArray<String>()
let t2 = list.GetType()
printfn $"{t2.FullName}"
// The example displays the following output:
// System.Collections.Generic.List`1
//
// System.Collections.Generic.List`1[[System.String, mscorlib,
//        Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
// </Snippet2>