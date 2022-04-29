//<Snippet1>
open System
open System.Collections
open System.Text
open System.Security.Policy
open System.Reflection
open System.Security

let main _ =
    //<Snippet2>
    printfn $"Full name = {AppDomain.CurrentDomain.ActivationContext.Identity.FullName}"
    //</Snippet2>
    //<Snippet3>
    printfn $"Code base = {AppDomain.CurrentDomain.ActivationContext.Identity.CodeBase}"
    //</Snippet3>
    //<Snippet6>
    //<Snippet7>
    let asi = ApplicationSecurityInfo AppDomain.CurrentDomain.ActivationContext

    printfn $"ApplicationId.Name property = {asi.ApplicationId.Name}"
    //</Snippet7>
    //<Snippet8>
    if asi.ApplicationId.Culture <> null then
        printfn $"ApplicationId.Culture property = {asi.ApplicationId.Culture}"
    //</Snippet8>
    //<Snippet9>
    printfn $"ApplicationId.ProcessorArchitecture property = {asi.ApplicationId.ProcessorArchitecture}"
    //</Snippet9>
    //<Snippet10>
    printfn $"ApplicationId.Version property = {asi.ApplicationId.Version}"
    //</Snippet10>
    //<Snippet11>
    // To display the value of the public key, enumerate the Byte array for the property.
    printf "ApplicationId.PublicKeyToken property = "
    let pk = asi.ApplicationId.PublicKeyToken
    for i = 0 to pk.GetLength 0 - 1 do
        printf $"{pk[i]:x}"
    //</Snippet11>
    //</Snippet6>
    Console.Read()
//</Snippet1>
