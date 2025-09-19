﻿' <Snippet1>
Imports System.Xml

public class Sample 

  public shared sub Main() 

       Dim doc as XmlDocument = new XmlDocument()
       doc.LoadXml("<book>" & _
                   "  <title>Oberon's Legacy</title>" & _
                   "  <price>5.95</price>" & _
                   "</book>") 
 
       ' Create a new element node.
       Dim newElem as XmlNode = doc.CreateNode("element", "pages", "")  
       newElem.InnerText = "290"
     
       Console.WriteLine("Add the new element to the document...")
       Dim root as XmlElement = doc.DocumentElement
       root.AppendChild(newElem)
     
       Console.WriteLine("Display the modified XML document...")
       Console.WriteLine(doc.OuterXml)
   end sub
end class
' </Snippet1>

