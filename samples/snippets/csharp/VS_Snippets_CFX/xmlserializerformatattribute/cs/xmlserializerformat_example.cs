using System;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace XmlSerializerFormatAttributeExample
{
    //<snippet1>
    [ServiceContract, XmlSerializerFormat(Style = OperationFormatStyle.Rpc,
        Use = OperationFormatUse.Encoded)]
    public interface ICalculator
    {
        [OperationContract, XmlSerializerFormat(Style = OperationFormatStyle.Rpc,
            Use = OperationFormatUse.Encoded)]
        double Add(double a, double b);
    }
    //</snippet1>

    public sealed class Test
    {
        private Test() { }
        public static void Main() { }
    }
}