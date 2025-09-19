// <Snippet1>	
namespace MyNamespace
    
type MyClass() = class end

namespace global

module Example = 
    let myType = typeof<MyNamespace.MyClass>
    printfn $"Displaying information about {myType}:"
    // Get the namespace of the myClass class.
    printfn $"   Namespace: {myType.Namespace}."
    // Get the name of the ilmodule.
    printfn $"   Module: {myType.Module}."
    // Get the fully qualified type name.
    printfn $"   Fully qualified name: {myType.ToString()}."
// The example displays the following output:
//    Displaying information about MyNamespace.MyClass:
//       Namespace: MyNamespace.
//       Module: type_tostring.exe.
//       Fully qualified name: MyNamespace.MyClass.
// </Snippet1>				