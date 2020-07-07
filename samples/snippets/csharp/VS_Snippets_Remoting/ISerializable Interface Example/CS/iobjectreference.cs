﻿//<snippet1>
using System;
using System.Text;
using System.IO;
// Add references to Soap and Binary formatters.
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap ;
using System.Runtime.Serialization;

[Serializable]
public class MyItemType : ISerializable
{
    public MyItemType()
    {
        // Empty constructor required to compile.
    }

    // The value to serialize.
    private string myProperty_value;

    public string MyProperty
    {
        get { return myProperty_value; }
        set { myProperty_value = value; }
    }

    // Implement this method to serialize data. The method is called
    // on serialization.
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        // Use the AddValue method to specify serialized values.
        info.AddValue("props", myProperty_value, typeof(string));
    }

    // The special constructor is used to deserialize values.
    public MyItemType(SerializationInfo info, StreamingContext context)
    {
        // Reset the property value using the GetValue method.
        myProperty_value = (string) info.GetValue("props", typeof(string));
    }
}

// This is a console application.
public static class Test
{
    static void Main()
    {
        // This is the name of the file holding the data. You can use any file extension you like.
        string fileName = "dataStuff.myData";

        // Use a BinaryFormatter or SoapFormatter.
        IFormatter formatter = new BinaryFormatter();
        //IFormatter formatter = new SoapFormatter();

        Test.SerializeItem(fileName, formatter); // Serialize an instance of the class.
        Test.DeserializeItem(fileName, formatter); // Deserialize the instance.
        Console.WriteLine("Done");
        Console.ReadLine();
    }

    public static void SerializeItem(string fileName, IFormatter formatter)
    {
        // Create an instance of the type and serialize it.
        MyItemType t = new MyItemType();
        t.MyProperty = "Hello World";

        FileStream s = new FileStream(fileName , FileMode.Create);
        formatter.Serialize(s, t);
        s.Close();
    }

    public static void DeserializeItem(string fileName, IFormatter formatter)
    {
        FileStream s = new FileStream(fileName, FileMode.Open);
        MyItemType t = (MyItemType)formatter.Deserialize(s);
        Console.WriteLine(t.MyProperty);
    }
}
//</snippet1>
