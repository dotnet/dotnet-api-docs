/*System::Net::HttpVersion::Version10
This program demonstrates the  'Version10' field of the 'HttpVersion' Class.
The 'Version'  property of 'HttpRequestMessage' class identifies the Version of HTTP being used.
Then the default value of 'Version' property is displayed to the console.
The 'Version10' field of the 'HttpVersion' class is assigned to the 'Version' property of the 'HttpRequestMessage' Class.
The changed Version and the 'Version' of the response object are displayed.
*/

#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Http;

int main()
{
   try
   {
      // <Snippet1>
      // HttpClient lifecycle management best practices:
      // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
      HttpClient^ client = gcnew HttpClient();

      HttpRequestMessage^ request = new HttpRequestMessage(HttpMethod::Get, "http://www.microsoft.com");
      Console::WriteLine("Default HTTP request version is {0}", request.Version);

      request.Version = HttpVersion.Version10;
      Console::WriteLine("Request version after assignment is {0}", request.Version);

      HttpResponseMessage^ response = client->Send(request);
      Console::WriteLine("Response HTTP version {0}", response.Version);
      // </Snippet1>
      Console::WriteLine("\nPress 'Enter' Key to Continue..............");
      Console::Read();
   }
   catch (HttpRequestException^ e)
   {
      Console::WriteLine("HttpRequestException Caught!");
      Console::WriteLine("Message : {0} ", e->Message);
      Console::WriteLine("Source  : {0} ", e->Source);
   }
   catch (Exception^ e)
   {
      Console::WriteLine("Exception Caught!");
      Console::WriteLine("Source  : {0}", e->Source);
      Console::WriteLine("Message : {0}", e->Message);
   }
}
