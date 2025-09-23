// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class OrderedItem1
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

public class Test1
{
    public static void Main(string[] args)
    {
        Test1 t = new();
        // Write a purchase order.
        t.SerializeObject("simple.xml");
    }

    private void SerializeObject(string filename)
    {
        Console.WriteLine("Writing With TextWriter");
        // Create an XmlSerializer instance using the type.
        XmlSerializer serializer = new(typeof(OrderedItem1));
        OrderedItem1 i = new()
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
        // Create a StreamWriter to write with.
        StreamWriter writer = new(filename);
        /* Serialize using the object using the TextWriter
        and namespaces. */
        serializer.Serialize(writer, i, ns);
        writer.Close();
    }
}

// </Snippet1>
