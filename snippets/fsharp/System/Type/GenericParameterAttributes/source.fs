//<Snippet1>
open System
open System.Reflection

// Define a sample interface to use as an interface constraint.
type ITest = interface end

// Define a base type to use as a base class constraint.
type Base() = class end

// Define the generic type to examine. The first generic type parameter,
// T, derives from the class Base and implements ITest. This demonstrates
// a base class constraint and an interface constraint. The second generic 
// type parameter, U, must be a reference type (class) and must have a 
// default constructor (new()). This demonstrates special constraints.
type Test<'T, 'U
    when 'T :> Base 
    and 'T :> ITest
    and 'U : not struct 
    and 'U : (new : unit -> 'U)>() = class end

// Define a type that derives from Base and implements ITest. This type
// satisfies the constraints on T in class Test.
type Derived() = 
    inherit Base()
    interface ITest

// List the variance and special constraint flags. 
let listGenericParameterAttributes (t: Type) =
    let gpa = t.GenericParameterAttributes
    let variance = gpa &&& GenericParameterAttributes.VarianceMask

    let mutable retval = 
        // Select the variance flags.
        if variance = GenericParameterAttributes.None then
            "No variance flag"
        else
            if variance &&& GenericParameterAttributes.Covariant |> int <> 0 then
                "Covariant"
            else
                "Contravariant"
    // Select 
    let constraints = gpa &&& GenericParameterAttributes.SpecialConstraintMask

    if constraints = GenericParameterAttributes.None then
        retval <- retval + " No special constraints"
    else
        if constraints &&& GenericParameterAttributes.ReferenceTypeConstraint |> int <> 0 then
            retval <- retval + " ReferenceTypeConstraint"
        if constraints &&& GenericParameterAttributes.NotNullableValueTypeConstraint |> int <> 0 then
            retval <- retval + " NotNullableValueTypeConstraint"
        if constraints &&& GenericParameterAttributes.DefaultConstructorConstraint |> int <> 0 then
            retval <- retval + " DefaultConstructorConstraint"
    retval


// To get the generic type definition, call .GetGenericTypeDefinition().
let def = typeof<Test<Derived, _>>.GetGenericTypeDefinition()
printfn $"\nExamining generic type {def}"

// Get the type parameters of the generic type definition,
// and display them.
let defparams = def.GetGenericArguments()
for tp in defparams do
    printfn $"\nType parameter: {tp.Name}"
    printfn $"\t{listGenericParameterAttributes tp}"

    // List the base class and interface constraints. The
    // constraints are returned in no particular order. If 
    // there are no class or interface constraints, an empty
    // array is returned.
    let tpConstraints = tp.GetGenericParameterConstraints()
    for tpc in tpConstraints do
        printfn $"\t{tpc}"

(* This example produces the following output:

Examining generic type Test`2[T,U]

Type parameter: T
        No variance flag no special constraints.
        Base
        ITest

Type parameter: U
        No variance flag ReferenceTypeConstraint DefaultConstructorConstraint
 *)
//</Snippet1>