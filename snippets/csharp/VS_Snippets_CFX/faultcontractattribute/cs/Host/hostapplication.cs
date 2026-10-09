using System;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.WCF.Documentation
{
  class HostApplication
  {

    static void Main(string[] args)
    {
      HostApplication app = new HostApplication();
      app.Run(args);
    }

    private void Run(string[] args)
    {
      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
      builder.WebHost.UseUrls("http://localhost:8080");
      builder.Services.AddServiceModelServices();
      builder.Services.AddServiceModelMetadata();

      WebApplication app = builder.Build();

      app.UseServiceModel(serviceBuilder =>
      {
        serviceBuilder.AddServiceEndpoint<SampleService, ISampleService>(
          new WSHttpBinding(SecurityMode.Message),
          "/SampleService");

        ServiceMetadataBehavior serviceMetadataBehavior =
          app.Services.GetRequiredService<ServiceMetadataBehavior>();
        serviceMetadataBehavior.HttpGetEnabled = true;
      });

      Console.WriteLine("The service is ready.");
      Console.WriteLine("Press Ctrl+C to terminate service.");
      app.Run();
    }
  }
}
