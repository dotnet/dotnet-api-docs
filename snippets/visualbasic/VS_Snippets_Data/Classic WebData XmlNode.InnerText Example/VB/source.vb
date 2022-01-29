﻿' <Snippet1>
Imports System.Xml

public class Test

  public shared sub Main()

    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<root>"& _
                "<elem>some text<child/>more text</elem>" & _
                "</root>")

    Dim elem as XmlNode = doc.DocumentElement.FirstChild

    ' Note that InnerText does not include the markup.
    Console.WriteLine("Display the InnerText of the element...")
    Console.WriteLine( elem.InnerText )

    ' InnerXml includes the markup of the element.
    Console.WriteLine("Display the InnerXml of the element...")
    Console.WriteLine(elem.InnerXml)

    ' Set InnerText to a string that includes markup.  
    ' The markup is escaped.
    elem.InnerText = "Text containing <markup/> will have char(<) and char(>) escaped."
    Console.WriteLine( elem.OuterXml )

    ' Set InnerXml to a string that includes markup.  
    ' The markup is not escaped.
    elem.InnerXml = "Text containing <markup/>."
    Console.WriteLine( elem.OuterXml )
    
  end sub
end class
' </Snippet1>

