using Microsoft.Extensions.Configuration;

IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
IConfigurationRoot root = builder.Build();

Console.WriteLine($"Hello, { root["weather"] } world!");

/* This program outputs the following text:
 * 
 * Hello, stormy world!
 */
