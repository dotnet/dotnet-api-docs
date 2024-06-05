module testissubclassof

// <Snippet1>
type Class1() = class end
type DerivedC1() = inherit Class1()

printfn $"DerivedC1 subclass of Class1: {typeof<DerivedC1>.IsSubclassOf typeof<Class1>}"

// The example displays the following output:
//        DerivedC1 subclass of Class1: True
// </Snippet1>