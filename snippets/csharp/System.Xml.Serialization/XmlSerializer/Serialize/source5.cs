// <Snippet1>
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class OrderedItem5
{
    [XmlElement(Namespace = "http://www.cpandl.com")]
    public string ItemName;
    [XmlElement(Namespace = "http://www.cpandl.com")]
    public string Description;
    [XmlElement(Namespace = "http://www.cohowinery.com")]
    public decimal UnitPrice;
    [XmlElement(Namespace = "http://www.cpandl.com")]
    public int Quantity;
    [XmlElement(Namespace = "http://www.cohowinery.com")]
    public decimal LineTotal;
    // A custom method used to calculate price per item.
    public void Calculate()
    {
        LineTotal = UnitPrice * Quantity;
    }
}

public class Test5
{
    public static void Main()
    {
        Test5 t = new();
        // Write a purchase order.
        t.SerializeObject("simple.xml");
    }

    private void SerializeObject(string filename)
    {
        Console.WriteLine("Writing With XmlTextWriter");

        XmlSerializer serializer = new(typeof(OrderedItem5));
        OrderedItem5 i = new()
        {
            ItemName = "Widget",
            Description = "Regular Widget",
            Quantity = 10,
            UnitPrice = (decimal)2.30
        };
        i.Calculate();

        // Create an XmlSerializerNamespaces object.
        XmlSerializerNamespaces ns = new();

        // Add two namespaces with prefixes.
        ns.Add("inventory", "http://www.cpandl.com");
        ns.Add("money", "http://www.cohowinery.com");

        // Create an XmlTextWriter using a FileStream.
        Stream fs = new FileStream(filename, FileMode.Create);
        XmlTextWriter writer = new(fs, new UTF8Encoding());

        // Serialize using the XmlTextWriter.
        serializer.Serialize(writer, i, ns);
        writer.Close();
    }
}
// </Snippet1>
