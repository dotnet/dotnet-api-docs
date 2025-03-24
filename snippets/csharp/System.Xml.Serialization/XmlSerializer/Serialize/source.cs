// <Snippet1>
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class OrderedItem
{
    public string ItemName;
    public string Description;
    public decimal UnitPrice;
    public int Quantity;
    public decimal LineTotal;
    // A custom method used to calculate price per item.
    public void Calculate()
    {
        LineTotal = UnitPrice * Quantity;
    }
}

public class Test
{
    public static void Main(string[] args)
    {
        Test t = new();
        // Write a purchase order.
        t.SerializeObject("simple.xml");
    }

    private void SerializeObject(string filename)
    {
        Console.WriteLine("Writing With TextWriter");

        XmlSerializer serializer = new(typeof(OrderedItem));
        OrderedItem i = new()
        {
            ItemName = "Widget",
            Description = "Regular Widget",
            Quantity = 10,
            UnitPrice = (decimal)2.30
        };
        i.Calculate();

        /* Create a StreamWriter to write with. First create a FileStream
           object, and create the StreamWriter specifying an Encoding to use. */
        FileStream fs = new(filename, FileMode.Create);
        StreamWriter writer = new(fs, new UTF8Encoding());
        // Serialize using the XmlTextWriter.
        serializer.Serialize(writer, i);
        writer.Close();
    }
}
// </Snippet1>
