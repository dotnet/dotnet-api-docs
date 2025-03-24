

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Net;
using namespace System::Net::Http;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   void Method()
   {
      // <Snippet1>
      Uri^ siteUri = gcnew Uri("http://www.contoso.com/");

      // HttpClient lifecycle management best practices:
      // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
      HttpClient^ client = gcnew HttpClient;
      HttpRequestMessage^ request = gcnew HttpRequestMessage(HttpMethod::Get, siteUri);
      HttpResponseMessage^ response = client->Send(request);
      // </Snippet1>
   }
};

void main()
{
   Form1^ f = gcnew Form1;
}
