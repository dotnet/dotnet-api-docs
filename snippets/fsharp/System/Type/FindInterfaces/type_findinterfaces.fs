// <Snippet1>
open System
open System.Xml
open System.Reflection

let myInterfaceFilter (typeObj: Type) (criteriaObj: obj) =
    string typeObj = string criteriaObj

try
    let myXMLDoc = XmlDocument()
    myXMLDoc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" + "<title>Pride And Prejudice</title>" + "</book>")
    let myType = myXMLDoc.GetType()

    // Specify the TypeFilter delegate that compares the
    // interfaces against filter criteria.
    let myFilter = TypeFilter myInterfaceFilter
    let myInterfaceList =
        [ "System.Collections.IEnumerable"
          "System.Collections.ICollection" ]
    for i in myInterfaceList do
        let myInterfaces = myType.FindInterfaces(myFilter, i)
        if myInterfaces.Length > 0 then
            printfn $"\n{myType} implements the interface {i}."
            for j in myInterfaces do
                printfn $"Interfaces supported: {j}."
        else
            printfn $"\n{myType} does not implement the interface {i}."
with
| :? ArgumentNullException as e ->
    printfn $"ArgumentNullException: {e.Message}"
| :? TargetInvocationException as e ->
    printfn $"TargetInvocationException: {e.Message}"
| e ->
    printfn $"Exception: {e.Message}"
// </Snippet1>