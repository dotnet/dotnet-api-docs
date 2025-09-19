// <Snippet1>
using System;
using System.IO;
using System.Xml.Serialization;

// This is the class that will be serialized.
public class OrderedItem2
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

public class Test2
{
    public static void Main(string[] args)
    {
        Test2 t = new();
        // Write a purchase order.
        t.SerializeObject("simple.xml");
    }

    private void SerializeObject(string filename)
    {
        Console.WriteLine("Writing With Stream");

        XmlSerializer serializer = new(typeof(OrderedItem2));
        OrderedItem2 i = new()
        {
            ItemName = "Widget",
            Description = "Regular Widget",
            Quantity = 10,
            UnitPrice = (decimal)2.30
        };
        i.Calculate();

        // Create a FileStream to write with.
        FileStream writer = new(filename, FileMode.Create);
        // Serialize the object, and close the TextWriter
        serializer.Serialize(writer, i);
        writer.Close();
    }
}

// </Snippet1>
