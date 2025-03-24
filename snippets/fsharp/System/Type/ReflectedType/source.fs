namespace global

// <Snippet1>
module MyModule =
    type [<AbstractClass>] MyClass() = class end

    printfn $"Reflected type of MyClass is {typeof<MyClass>.ReflectedType}" // Outputs MyModule, the enclosing module.
// </Snippet1>