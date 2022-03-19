

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book ISBN='1-861001-57-5'>"
   "<title>Pride And Prejudice</title>"
   "<price>19.95</price>"
   "</book>" );
   XmlNode^ root = doc->FirstChild;
   
   //Clone the root node.  The cloned node includes
   //child nodes. This is similar to calling CloneNode(true).
   XmlNode^ clone = root->Clone();
   Console::WriteLine( clone->OuterXml );
}

// </Snippet1>
