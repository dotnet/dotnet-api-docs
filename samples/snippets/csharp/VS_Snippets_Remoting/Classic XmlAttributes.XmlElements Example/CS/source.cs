﻿// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Xml;

public class Transportation
{
   // Subsequent code overrides these two XmlElementAttributes.
   [XmlElement(typeof(Car)),
   XmlElement(typeof(Plane))]
   public ArrayList Vehicles;
}

public class Car
{
   public string Name;
}

public class Plane
{
   public string Name;
}
public class Truck
{
   public string Name;
}
public class Train
{
   public string Name;
}

public class Test
{
   public static void Main()
   {
      Test t = new Test();
      t.SerializeObject("OverrideElement.xml");
   }

   // Return an XmlSerializer used for overriding.
   public XmlSerializer CreateOverrider()
   {
      // Create the XmlAttributes and XmlAttributeOverrides objects.
      XmlAttributes attrs = new XmlAttributes();

      XmlAttributeOverrides xOver =
      new XmlAttributeOverrides();

      /* Create an XmlElementAttribute to override
      the Vehicles property. */
      XmlElementAttribute xElement1 =
      new XmlElementAttribute(typeof(Truck));
      // Add the XmlElementAttribute to the collection.
      attrs.XmlElements.Add(xElement1);

      /* Create a second XmlElementAttribute, and
      add it to the collection. */
      XmlElementAttribute xElement2 =
      new XmlElementAttribute(typeof(Train));
      attrs.XmlElements.Add(xElement2);

      /* Add the XmlAttributes to the XmlAttributeOverrides,
      specifying the member to override. */
      xOver.Add(typeof(Transportation), "Vehicles", attrs);

      // Create the XmlSerializer, and return it.
      XmlSerializer xSer = new XmlSerializer
      (typeof(Transportation), xOver);
      return xSer;
   }

   public void SerializeObject(string filename)
   {
      // Create an XmlSerializer instance.
      XmlSerializer xSer = CreateOverrider();

      // Create the object and serialize it.
      Transportation myTransportation =
      new Transportation();

      /* Create two new override objects that can be
      inserted into the array. */
      myTransportation.Vehicles = new ArrayList();
      Truck myTruck = new Truck();
      myTruck.Name = "MyTruck";

      Train myTrain = new Train();
      myTrain.Name = "MyTrain";

      myTransportation.Vehicles.Add(myTruck);
      myTransportation.Vehicles.Add(myTrain);

      TextWriter writer = new StreamWriter(filename);
      xSer.Serialize(writer, myTransportation);
   }
}

// </Snippet1>
