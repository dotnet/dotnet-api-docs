//  <SNIPPET1>
open System

// Create application domain setup information
let domaininfo = AppDomainSetup()

//Create evidence for the new appdomain from evidence of the current application domain
let adevidence = AppDomain.CurrentDomain.Evidence

// Create appdomain
let domain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo)

// Write out application domain information
printfn $"Host domain: {AppDomain.CurrentDomain.FriendlyName}"
printfn $"child domain: {domain.FriendlyName}"
printfn $"child domain name using ToString:{domain}\n"

AppDomain.Unload domain
//  </SNIPPET1>