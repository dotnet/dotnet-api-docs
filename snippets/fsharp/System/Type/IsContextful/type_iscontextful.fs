// <Snippet1>
open System

type ContextBoundClass() as this =
    inherit ContextBoundObject()
    [<DefaultValue>]
    val mutable public Value : string 
    do 
        this.Value <- "The Value property."

type Example() = class end

// Determine whether the types can be hosted in a Context.
printfn $"The IsContextful property for the {typeof<Example>.Name} type is {typeof<Example>.IsContextful}."
printfn $"The IsContextful property for the {typeof<ContextBoundClass>.Name} type is {typeof<ContextBoundClass>.IsContextful}."

// Determine whether the types are marshalled by reference.
printfn $"The IsMarshalByRef property of {typeof<Example>.Name} is {typeof<Example>.IsMarshalByRef}."
printfn $"The IsMarshalByRef property of {typeof<ContextBoundClass>.Name} is {typeof<ContextBoundClass>.IsMarshalByRef}."

// Determine whether the types are primitive datatypes.
printfn $"{typeof<int>.Name} is a primitive data type: {typeof<int>.IsPrimitive}."
printfn $"{typeof<string>.Name} is a primitive data type: {typeof<string>.IsPrimitive}."
// The example displays the following output:
//    The IsContextful property for the Example type is False.
//    The IsContextful property for the ContextBoundClass type is True.
//    The IsMarshalByRef property of Example is False.
//    The IsMarshalByRef property of ContextBoundClass is True.
//    Int32 is a primitive data type: True.
//    String is a primitive data type: False.
// </Snippet1>