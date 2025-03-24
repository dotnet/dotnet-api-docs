//<Snippet1>
open System

// This attribute is only valid on a class.
[<AttributeUsage(AttributeTargets.Class)>]
type ClassTargetAttribute() =
    inherit Attribute()

// This attribute is only valid on a method.
[<AttributeUsage(AttributeTargets.Method)>]
type MethodTargetAttribute() =
    inherit Attribute()

// This attribute is only valid on a constructor.
[<AttributeUsage(AttributeTargets.Constructor)>]
type ConstructorTargetAttribute() =
    inherit Attribute()

// This attribute is only valid on a field.
[<AttributeUsage(AttributeTargets.Field)>]
type FieldTargetAttribute() =
    inherit Attribute()

// This attribute is valid on a class or a method.
[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Method)>]
type ClassMethodTargetAttribute() =
    inherit Attribute()

// This attribute is valid on a generic type parameter.
[<AttributeUsage(AttributeTargets.GenericParameter)>]
type GenericParameterTargetAttribute() =
    inherit Attribute()

// This attribute is valid on any target.
[<AttributeUsage(AttributeTargets.All)>]
type AllTargetsAttribute() =
    inherit Attribute()

[<ClassTarget>]
[<ClassMethodTarget>]
[<AllTargets>]
type TestClassAttribute [<ConstructorTarget>] [<AllTargets>] () =
    [<FieldTarget>]
    [<AllTargets>]
    let myInt = 0

    [<MethodTarget>]
    [<ClassMethodTarget>]
    [<AllTargets>]
    member _.Method1() = ()

    member _.GenericMethod<[<GenericParameterTarget; AllTargets>] 'T>(x: 'T) = ()

//</Snippet1>