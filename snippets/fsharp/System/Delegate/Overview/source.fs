// <Snippet1>
// Declares a delegate for a method that takes in an int and returns a string.
type MyMethodDelegate = delegate of int -> string

// Defines some methods to which the delegate can point.
type MySampleClass() =
    // Defines an instance method.
    member _.MyStringMethod(myInt) =
        if myInt > 0 then "positive"
        elif myInt < 0 then "negative"
        else "zero"

    // Defines a static method.
    static member MySignMethod(myInt) =
        if myInt > 0 then "+"
        elif myInt < 0 then "-"
        else ""

// Creates one delegate for each method. For the instance method, an
// instance (mySC) must be supplied. For the static method, use the
// class name.
let mySC = MySampleClass()
let myD1 = MyMethodDelegate mySC.MyStringMethod
let myD2 = MyMethodDelegate MySampleClass.MySignMethod

// Invokes the delegates.
printfn $"{5} is {myD1.Invoke 5} use the sign \"{myD2.Invoke 5}\"."
printfn $"{-3} is {myD1.Invoke -3} use the sign \"{myD2.Invoke -3}\"."
printfn $"{0} is {myD1.Invoke 0} use the sign \"{myD2.Invoke 0}\"."

// This code produces the following output:
//     5 is positive use the sign "+".
//     -3 is negative use the sign "-".
//     0 is zero use the sign "".
// </Snippet1>