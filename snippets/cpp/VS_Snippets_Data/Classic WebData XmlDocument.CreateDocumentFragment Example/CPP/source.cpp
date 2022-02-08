

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<items/>" );
   
   //Create a document fragment.
   XmlDocumentFragment^ docFrag = doc->CreateDocumentFragment();
   
   //Set the contents of the document fragment.
   docFrag->InnerXml = "<item>widget</item>";
   
   //Add the children of the document fragment to the
   //original document.
   doc->DocumentElement->AppendChild( docFrag );
   Console::WriteLine( "Display the modified XML..." );
   Console::WriteLine( doc->OuterXml );
}

// </Snippet1>
