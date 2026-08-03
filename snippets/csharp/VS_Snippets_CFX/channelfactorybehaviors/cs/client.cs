using System;
using System.ServiceModel;
using Microsoft.WCF.Documentation;

// <snippet10>
public class Client
{
  public static void Main()
  {
    try
    {
      WSHttpBinding binding = new(SecurityMode.Message);
      EndpointAddress address = new("http://localhost:8080/ServiceMetadata/SampleService");
      ChannelFactory<ISampleServiceChannel> factory
        = new(binding, address);

      // Add the client side behavior programmatically to all created channels.
      factory.Endpoint.EndpointBehaviors.Add(new EndpointBehaviorMessageInspector());

      ISampleServiceChannel wcfClientChannel = factory.CreateChannel();

      // Making calls.
      Console.WriteLine("Enter the greeting to send: ");
      string greeting = Console.ReadLine();
      Console.WriteLine("The service responded: " + wcfClientChannel.SampleMethod(greeting));

      Console.WriteLine("Press ENTER to exit:");
      Console.ReadLine();

      // Done with service.
      wcfClientChannel.Close();
      Console.WriteLine("Done!");
    }
    catch (TimeoutException timeProblem)
    {
      Console.WriteLine("The service operation timed out. " + timeProblem.Message);
      Console.Read();
    }
    catch (FaultException<SampleFault> fault)
    {
      Console.WriteLine("SampleFault fault occurred: {0}", fault.Detail.FaultMessage);
      Console.Read();
    }
    catch (CommunicationException commProblem)
    {
      Console.WriteLine("There was a communication problem. " + commProblem.Message);
      Console.Read();
    }
  }
  // </snippet10>
}
