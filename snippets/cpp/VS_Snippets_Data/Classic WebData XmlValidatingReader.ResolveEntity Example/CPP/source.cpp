

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlValidatingReader^ reader = nullptr;
   XmlTextReader^ txtreader = nullptr;
   try
   {
      
      //Create and load the XmlTextReader with the XML file. 
      txtreader = gcnew XmlTextReader( "book1.xml" );
      txtreader->WhitespaceHandling = WhitespaceHandling::None;
      
      //Create the XmlValidatingReader over the XmlTextReader.
      //Set the reader to not expand general entities.
      reader = gcnew XmlValidatingReader( txtreader );
      reader->ValidationType = ValidationType::None;
      reader->EntityHandling = EntityHandling::ExpandCharEntities;
      reader->MoveToContent(); //Move to the root element.
      reader->Read(); //Move to title start tag.
      reader->Skip(); //Skip the title element.
      
      //Read the misc start tag.  The reader is now positioned on
      //the entity reference node.
      reader->ReadStartElement();
      
      //Because EntityHandling is set to ExpandCharEntities, you must call 
      //ResolveEntity to expand the entity.  The entity replacement text is 
      //then parsed and returned as a child node.         
      Console::WriteLine( "Expand the entity..." );
      reader->ResolveEntity();
      Console::WriteLine( "The entity replacement text is returned as a text node." );
      reader->Read();
      Console::WriteLine( "NodeType: {0} Value: {1}", reader->NodeType, reader->Value );
      Console::WriteLine( "An EndEntity node closes the entity reference scope." );
      reader->Read();
      Console::WriteLine( "NodeType: {0} Name: {1}", reader->NodeType, reader->Name );
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
