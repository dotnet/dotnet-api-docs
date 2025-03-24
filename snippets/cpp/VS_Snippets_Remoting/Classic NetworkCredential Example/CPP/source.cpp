#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Http;
using namespace System::IO;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
public:
   void Method()
   {
      String^ SecurelyStoredUserName = "";
      String^ SecurelyStoredPassword = "";
      String^ SecurelyStoredDomain = "";
      
      // <Snippet1>
      NetworkCredential^ myCred = gcnew NetworkCredential(
         SecurelyStoredUserName,SecurelyStoredPassword,SecurelyStoredDomain );

      CredentialCache^ myCache = gcnew CredentialCache;

      myCache->Add( gcnew Uri( "http://www.contoso.com" ), "Basic", myCred );
      myCache->Add( gcnew Uri( "http://app.contoso.com" ), "Basic", myCred );

      // HttpClient lifecycle management best practices:
      // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
      HttpClientHandler^ handler = gcnew HttpClientHandler();
      handler->Credentials = myCache;
      HttpClient^ client = gcnew HttpClient(handler);
      // </Snippet1>
   }
};
