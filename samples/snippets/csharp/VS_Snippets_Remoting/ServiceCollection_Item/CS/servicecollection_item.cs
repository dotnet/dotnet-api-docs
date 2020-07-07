﻿// System.Web.Services.Description.ServiceDescription.Write(FileName)
// System.Web.Services.Description.ServiceCollection.Remove
// System.Web.Services.Description.ServiceCollection.Item(int)
// System.Web.Services.Description.ServiceDescription.Services
// System.Web.Services.Description.ServiceDescription.TargetNamespace
// System.Web.Services.Description.ServiceCollection.Add
/*
   The following example demonstrates methods and properties of the
   ServiceDescription and ServiceCollection classes.
   A new WSDL is read and the existing service "MathService" in the
   ServiceCollection is removed. The service by default is defined for
   SOAP, HttpGet, HttpPost. A new Service defined for SOAP and HttpGet is
   constructed and added to the ServiceCollection.
   The programs writes a new web service description file.
*/

using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyClass1
{
   public static void Main()
   {
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
      // Read a ServiceDescription from existing WSDL.
      ServiceDescription myServiceDescription =
         ServiceDescription.Read("Input_CS.wsdl");
      myServiceDescription.TargetNamespace = "http://tempuri.org/";
// </Snippet5>

      // Get the ServiceCollection of the ServiceDescription.
      ServiceCollection myServiceCollection = myServiceDescription.Services;

      // Remove the Service at index 0 of the collection.
      myServiceCollection.Remove(myServiceDescription.Services[0]);
// </Snippet4>
// </Snippet3>
// </Snippet2>

// <Snippet6>
      // Build a new Service.
      Service myService = new Service();
      myService.Name = "MathService";
      XmlQualifiedName myXmlQualifiedName =
         new XmlQualifiedName("s0:MathServiceSoap");

      // Build a new Port for SOAP.
      Port mySoapPort= new Port();

      mySoapPort.Name = "MathServiceSoap";

      mySoapPort.Binding = myXmlQualifiedName;

      SoapAddressBinding mySoapAddressBinding = new SoapAddressBinding();
      mySoapAddressBinding.Location =
         "http://localhost/ServiceCollection_Item/AddSub_CS.asmx";
      mySoapPort.Extensions.Add(mySoapAddressBinding);

      // Build a new Port for HTTP-GET.
      XmlQualifiedName myXmlQualifiedName2 =
         new XmlQualifiedName("s0:MathServiceHttpGet");

      Port myHttpGetPort= new Port();
      myHttpGetPort.Name="MathServiceHttpGet";
      myHttpGetPort.Binding=myXmlQualifiedName2;
      HttpAddressBinding myHttpAddressBinding = new HttpAddressBinding();
      myHttpAddressBinding.Location =
         "http://localhost/ServiceCollection_Item/AddSub_CS.asmx";
      myHttpGetPort.Extensions.Add(myHttpAddressBinding);

      // Add the ports to the service.
      myService.Ports.Add(myHttpGetPort);
      myService.Ports.Add(mySoapPort);

      // Add the service to the ServiceCollection.
      myServiceCollection .Add(myService);
// </Snippet6>

      // Write to a new WSDL file.
      myServiceDescription.Write("output.wsdl");
// </Snippet1>
   }
}
