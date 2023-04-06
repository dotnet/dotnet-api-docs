#using <System.dll>
#using <System.Web.dll>

using namespace System;
using namespace System::Web::UI;
using namespace System::Web::UI::WebControls;

public ref class MyControl: public Control
{
protected:
   virtual void Render( HtmlTextWriter^ writer ) override
   {
   // <snippet1>
      writer->AddAttribute( HtmlTextWriterAttribute::Onclick, "alert('Hello');" );
   // </snippet1>
      writer->AddAttribute( "myattribute", "MyAttributeValue" );
   // <snippet2>
      writer->AddStyleAttribute( HtmlTextWriterStyle::Color, "Red" );
   // </snippet2>
      writer->AddStyleAttribute( "mystyleattr", "StyleValue" );
      writer->RenderBeginTag( HtmlTextWriterTag::Span );
      writer->WriteLine();
      writer->Indent++;

      writer->Write( "Hello" );
      writer->WriteLine();
      
   // <snippet3>
      // Control the encoding of attributes.
      // Simple known values do not need encoding.
      writer->AddAttribute( HtmlTextWriterAttribute::Alt, "Encoding, \"Required\"", true );
      writer->AddAttribute( "myattribute", "No &quot;encoding &quot; required", false );
      writer->RenderBeginTag( HtmlTextWriterTag::Img );
      writer->RenderEndTag();
      writer->WriteLine();
   // </snippet3>

   // <snippet4>
      // Create a non-standard tag.
      writer->RenderBeginTag( "MyTag" );
      writer->Write( "Contents of MyTag" );
      writer->RenderEndTag();
      writer->WriteLine();
   // </snippet4>

   // <snippet5>
      // Create a manually rendered tag.
      writer->WriteBeginTag( "img" );
      writer->WriteAttribute( "alt", "AtlValue" );
      writer->WriteAttribute( "myattribute", "No &quot;encoding &quot; required", false );
      writer->Write( HtmlTextWriter::TagRightChar );
      writer->WriteEndTag( "img" );
   // </snippet5>
      writer->WriteLine();

      writer->Indent--;
      writer->RenderEndTag();
   }
};
