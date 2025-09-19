open System
// <Snippet1>
let ad = AppDomain.CreateDomain "ChildDomain"
ad.Load "MyAssembly"
// </Snippet1>
|> ignore