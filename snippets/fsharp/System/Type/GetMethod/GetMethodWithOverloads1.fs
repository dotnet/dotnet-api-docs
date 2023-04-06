module GetMethodWithOverloads1

// <Snippet2>
open System
open System.Reflection

type TestClass() =
    member _.DisplayValue(s) = 
        printfn $"%s{s}"

    member _.DisplayValue(s: string, [<ParamArray>]values: obj[]) =
        Console.WriteLine(s, values)

    member this.Equals(t: TestClass) =
        Object.ReferenceEquals(this, t)

    static member Equals(t1: TestClass, t2: TestClass) =
        Object.ReferenceEquals(t1, t2)

let retrieveMethod (t: Type) name (flags: BindingFlags) =
    try
        let m = t.GetMethod(name, flags)
        if m <> null then
            printf $"{t.Name}.{m.Name}("
            let parms = m.GetParameters()
            for i = 0 to parms.Length - 1 do
                printf $"{parms[i].ParameterType.Name}"
                if i < parms.Length - 1 then
                    printf ", "
            printfn ")"
        else
            printfn "Method not found"
    with :? AmbiguousMatchException ->
        printfn "The following duplicate matches were found:"
        let methods = t.GetMethods flags
        for method in methods do
            if method.Name = name then
                printf $"   {t.Name}.{method.Name}("
                let parms = method.GetParameters()
                for i = 0 to parms.Length - 1 do
                    printf $"{parms[i].ParameterType.Name}"
                    if i < parms.Length - 1 then
                        printf ", "
                printfn ")"
    printfn ""

let t = typeof<TestClass>

retrieveMethod t "DisplayValue" (BindingFlags.Public ||| BindingFlags.Instance)

retrieveMethod t "Equals" (BindingFlags.Public ||| BindingFlags.Instance)

retrieveMethod t "Equals" (BindingFlags.Public ||| BindingFlags.Instance ||| BindingFlags.DeclaredOnly)

retrieveMethod t "Equals" (BindingFlags.Public ||| BindingFlags.Static)

// The example displays the following output:
//       The following duplicate matches were found:
//          TestClass.DisplayValue(String)
//          TestClass.DisplayValue(String, Object[])
//       
//       The following duplicate matches were found:
//          TestClass.Equals(TestClass)
//          TestClass.Equals(Object)
//       
//       TestClass.Equals(TestClass)
//       
//       TestClass.Equals(TestClass, TestClass)
// </Snippet2>