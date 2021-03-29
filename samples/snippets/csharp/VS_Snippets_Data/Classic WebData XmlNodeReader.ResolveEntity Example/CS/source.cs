﻿// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
     XmlNodeReader reader = null;

     try
     {
       //Create and load an XML document.
       XmlDocument doc = new XmlDocument();
       doc.LoadXml("<!DOCTYPE book [<!ENTITY h 'hardcover'>]>" +
                   "<book>" +
                   "<title>Pride And Prejudice</title>" +
                   "<misc>&h;</misc>" +
                   "</book>");

       //Create the reader.
       reader = new XmlNodeReader(doc);

       reader.MoveToContent();  //Move to the root element.
       reader.Read();  //Move to title start tag.
       reader.Skip();  //Skip the title element.

       //Read the misc start tag.  The reader is now positioned on
       //the entity reference node.
       reader.ReadStartElement();

       //You must call ResolveEntity to expand the entity reference.
       //The entity replacement text is then parsed and returned as a child node.
       Console.WriteLine("Expand the entity...");
       reader.ResolveEntity();

       Console.WriteLine("The entity replacement text is returned as a text node.");
       reader.Read();
       Console.WriteLine("NodeType: {0} Value: {1}", reader.NodeType ,reader.Value);

       Console.WriteLine("An EndEntity node closes the entity reference scope.");
       reader.Read();
       Console.WriteLine("NodeType: {0} Name: {1}", reader.NodeType,reader.Name);
    }
    finally
    {
       if (reader != null)
         reader.Close();
    }
  }
}
// </Snippet1>
