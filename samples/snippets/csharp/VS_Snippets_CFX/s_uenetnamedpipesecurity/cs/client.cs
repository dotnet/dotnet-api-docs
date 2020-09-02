﻿
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedwcfClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a WCF client with given client endpoint configuration
            CalculatorClient wcfClient = new CalculatorClient();
            try
            {
              // Call the Add service operation.
              double value1 = 100.00D;
              double value2 = 15.99D;
              double result = wcfClient.Add(value1, value2);
              Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

              // Call the Subtract service operation.
              value1 = 145.00D;
              value2 = 76.54D;
              result = wcfClient.Subtract(value1, value2);
              Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

              // Call the Multiply service operation.
              value1 = 9.00D;
              value2 = 81.25D;
              result = wcfClient.Multiply(value1, value2);
              Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

              // Call the Divide service operation.
              value1 = 22.00D;
              value2 = 7.00D;
              result = wcfClient.Divide(value1, value2);
              Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
           }
           catch (TimeoutException timeProblem)
           {
             Console.WriteLine("The service operation timed out. " + timeProblem.Message);
             Console.ReadLine();
             wcfClient.Abort();
           }
           catch (CommunicationException commProblem)
           {
             Console.WriteLine("There was a communication problem. "
               + commProblem.Message + commProblem.StackTrace);
             Console.ReadLine();
             wcfClient.Abort();
           }

          Console.WriteLine();
          Console.WriteLine("Press <ENTER> to terminate client.");
          Console.ReadLine();
        }
    }
}
