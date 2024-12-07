//Snippet for System.ServiceModel.Description.ServiceCredentials
//
using System;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.ServiceModel.Samples
{

    //<snippet10>
    [ServiceContract]
    interface IMyService
    {

        //Define the contract operations.
    }

    class MyService : IMyService
    {

        //Implement the IMyService operations.
    }
    //</snippet10>

    public class Test
    {

        private void CreateNetTcpBinding()
        {
            NetTcpBinding b = new NetTcpBinding();
            b.Security.Mode = SecurityMode.Message;
            Type c = typeof(SayHello);

            //<snippet4>
            Uri a = new Uri("net.tcp://MyMachineName/tcpBase");
            Uri[] baseAddresses = new Uri[] { a };
            ServiceHost sh = new ServiceHost(typeof(SayHello), baseAddresses);
            sh.AddServiceEndpoint(c, b, "Aloha");
            sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindByThumbprint,
                "af1f50b20cd413ed9cd00c315bbb6dc1c08da5e6");
            sh.Open();
            //</snippet4>
        }
    }
}
