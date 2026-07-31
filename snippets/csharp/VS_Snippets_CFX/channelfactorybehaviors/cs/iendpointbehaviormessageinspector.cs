
// <snippet1>
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Microsoft.WCF.Documentation
{
  class EndpointBehaviorMessageInspector : IEndpointBehavior, IClientMessageInspector
  {
    //<snippet4>
    // IEndpointBehavior Members
    public void AddBindingParameters(ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
    {
      return;
    }

    public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
    {
      behavior.ClientMessageInspectors.Add(new EndpointBehaviorMessageInspector());
    }

    public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
    {
      return;
    }

    public void Validate(ServiceEndpoint serviceEndpoint)
    {
      return;
    }
    //</snippet4>

    //<snippet3>
    // Sample helper for creating the behavior instance in modern .NET builds.
    public static EndpointBehaviorMessageInspector CreateBehavior()
    {
      return new EndpointBehaviorMessageInspector();
    }
    //</snippet3>

    //<snippet2>
    // IClientMessageInspector members
    //</snippet2>

    #region IClientMessageInspector Members

    public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
    {
      Console.WriteLine("AfterReceiveReply called.");
    }

    public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
    {
      Console.WriteLine("BeforeSendRequest called.");
      return null;
    }

    #endregion
  }
}
// </snippet1>
