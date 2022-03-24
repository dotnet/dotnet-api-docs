

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlTextReader^ txtreader = nullptr;
   XmlValidatingReader^ reader = nullptr;
   try
   {
      
      //Implement the readers.
      txtreader = gcnew XmlTextReader( "elems.xml" );
      reader = gcnew XmlValidatingReader( txtreader );
      
      //Parse the XML and display the text content of each of the elements.
      while ( reader->Read() )
      {
         if ( reader->IsStartElement() )
         {
            if ( reader->IsEmptyElement )
                        Console::WriteLine( "<{0}/>", reader->Name );
            else
            {
               Console::Write( "<{0}> ", reader->Name );
               reader->Read(); //Read the start tag.
               if ( reader->IsStartElement() )
                              
               //Handle nested elements.
               Console::Write( "\r\n<{0}>", reader->Name );
               Console::WriteLine( reader->ReadString() ); //Read the text content of the element.
            }
         }
      }
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
