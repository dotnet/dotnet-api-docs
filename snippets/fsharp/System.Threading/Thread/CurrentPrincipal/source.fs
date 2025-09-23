// <Snippet1>
open System.Security
open System.Security.Principal
open System.Threading

let rolesArray = [| "managers"; "executives" |]

try
    // Set the principal to a new generic principal.
    Thread.CurrentPrincipal <- GenericPrincipal(GenericIdentity("Bob", "Passport"), rolesArray)
with :? SecurityException as secureException ->
    printfn $"{secureException.GetType().Name}: Permission to set Principal is denied."

let threadPrincipal = Thread.CurrentPrincipal

printfn $"Name: {threadPrincipal.Identity.Name}\nIsAuthenticated: {threadPrincipal.Identity.IsAuthenticated}\nAuthenticationType: {threadPrincipal.Identity.AuthenticationType}"
// </Snippet1>
