open System
open System.Runtime.Remoting.Lifetime
open System.Security.Permissions

// <Snippet1>
type MyClass() =
    inherit MarshalByRefObject()
   
    override _.InitializeLifetimeService() =
        let lease = base.InitializeLifetimeService() :?> ILease
        if lease.CurrentState = LeaseState.Initial then
            lease.InitialLeaseTime <- TimeSpan.FromMinutes 1
            lease.SponsorshipTimeout <- TimeSpan.FromMinutes 2
            lease.RenewOnCallTime <- TimeSpan.FromSeconds 2
        lease
// </Snippet1>
