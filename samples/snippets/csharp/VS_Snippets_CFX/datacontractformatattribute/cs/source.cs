using System;
using System.Collections;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Microsoft.ServiceModel.Samples
{

    public sealed class Test
    {

        public static void Main()
        {
        }
    }

    //<snippet1>
    [ServiceContract, DataContractFormat(Style = OperationFormatStyle.Rpc)]
    interface ICalculator
    {
        [OperationContract, DataContractFormat(Style = OperationFormatStyle.Rpc)]
        double Add(double a, double b);

        [OperationContract, DataContractFormat(Style = OperationFormatStyle.Document)]
        double Subtract(double a, double b);
    }
    //</snippet1>
}