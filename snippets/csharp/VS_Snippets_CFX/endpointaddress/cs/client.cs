using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

[ServiceContract]
public interface ISampleService
{
  [OperationContract]
  string SampleMethod(string message);
}

public class SampleServiceProxy : ClientBase<ISampleService>, ISampleService
{
  public string SampleMethod(string message)
  {
    return Channel.SampleMethod(message);
  }
}

public class Client
{
  public static void Run()
  {
    // Picks up configuration from the config file.
      using (SampleServiceProxy proxy = new SampleServiceProxy())
      {
          try
          {
              // Making calls.
              Console.WriteLine("Enter the greeting to send: ");
              string greeting = Console.ReadLine();
              Console.WriteLine("The service responded: " + proxy.SampleMethod(greeting));

              Console.WriteLine("Press ENTER to exit:");
              Console.ReadLine();

              // Done with service.
              proxy.Close();
              Console.WriteLine("Done!");
          }
          catch (TimeoutException timeProblem)
          {
              Console.WriteLine("The service operation timed out. " + timeProblem.Message);
          }
          catch(CommunicationException commProblem)
          {
              Console.WriteLine("There was a communication problem. " + commProblem.Message);
          }
      }
  }
}
