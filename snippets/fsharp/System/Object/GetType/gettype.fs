module gettype

// <Snippet1>
type MyBaseClass() = class end

type MyDerivedClass() = 
    inherit MyBaseClass()

let myBase = MyBaseClass()
let myDerived = MyDerivedClass()
let o: obj = myDerived
let b: MyBaseClass = myDerived

printfn $"mybase: Type is {myBase.GetType()}"
printfn $"myDerived: Type is {myDerived.GetType()}"
printfn $"object o = myDerived: Type is {o.GetType()}"
printfn $"MyBaseClass b = myDerived: Type is {b.GetType()}"
// The example displays the following output:
//    mybase: Type is MyBaseClass
//    myDerived: Type is MyDerivedClass
//    object o = myDerived: Type is MyDerivedClass
//    MyBaseClass b = myDerived: Type is MyDerivedClass
// </Snippet1>