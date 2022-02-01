using System.Data.Services;

namespace NorthwindService
{
    //<snippetNorthwindServiceFull>
    public class Northwind : DataService<NorthwindEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // Grant only the rights needed to support the client application.
            config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead
                 | EntitySetRights.WriteMerge
                 | EntitySetRights.WriteReplace);
            config.SetEntitySetAccessRule("Order_Details", EntitySetRights.AllRead
                | EntitySetRights.AllWrite);
            config.SetEntitySetAccessRule("Customers", EntitySetRights.AllRead);
        }
    }
    //</snippetNorthwindServiceFull>

    public class NorthwindEntities { }
}
