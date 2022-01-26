using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder();
IConfigurationBuilder builder = config.AddJsonFile("appsettings.json", false, true);
IConfigurationRoot root = builder.Build();

Console.WriteLine($"Hello, { root["weather"] } world!");
