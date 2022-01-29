

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Create a writer to write XML to the console.
   XmlTextWriter^ writer = nullptr;
   writer = gcnew XmlTextWriter( Console::Out );
   
   //Use indentation for readability.
   writer->Formatting = Formatting::Indented;
   writer->Indentation = 4;
   
   //Write an element (this one is the root).
   writer->WriteStartElement( "book" );
   
   //Write the title element.
   writer->WriteStartElement( "title" );
   writer->WriteString( "Pride And Prejudice" );
   writer->WriteEndElement();
   
   //Write the close tag for the root element.
   writer->WriteEndElement();
   
   //Write the XML to file and close the writer.
   writer->Close();
}

// </Snippet1>
