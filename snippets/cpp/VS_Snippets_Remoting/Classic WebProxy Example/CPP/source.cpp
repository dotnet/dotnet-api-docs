#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Http;

public ref class Sample
{
private:
   void sampleFunction()
   {
      // <Snippet1>
      WebProxy^ proxyObject = gcnew WebProxy("http://proxyserver:80/", true);

      // HttpClient lifecycle management best practices:
      // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
      HttpClientHandler^ handler = gcnew HttpClientHandler();
      handler->Proxy = proxyObject;
      HttpClient^ client = gcnew HttpClient(handler);
      // </Snippet1>
   }
};
