using System;
using System.Runtime.Remoting.Lifetime;

// <Snippet1>
 public class MyClass : MarshalByRefObject
 {
   public override Object InitializeLifetimeService()
   {
     ILease lease = (ILease)base.InitializeLifetimeService();
     if (lease.CurrentState == LeaseState.Initial)
     {
          lease.InitialLeaseTime = TimeSpan.FromMinutes(1);
          lease.SponsorshipTimeout = TimeSpan.FromMinutes(2);
           lease.RenewOnCallTime = TimeSpan.FromSeconds(2);
     }
       return lease;
   }
 }
// </Snippet1>
