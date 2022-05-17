// <Snippet1>
namespace Corporate.EmployeeObjects

[<Struct>]
type EmployeeA =
    val mutable Name : string

[<Struct>]
type EmployeeB =
    val mutable Name : string
    override this.ToString() = 
          this.Name

module Example =
     let empA = EmployeeA(Name="Robert")
     printfn $"{empA}"

     let empB = EmployeeB(Name="Robert")
     printfn $"{empB}"
// The example displays the following output:
//     Corporate.EmployeeObjects.EmployeeA
//     Robert
// </Snippet1>