﻿// System.Web.Services.Description.ServiceDescriptionCollection.Insert()
// System.Web.Services.Description.ServiceDescriptionCollection.Item(String)
// System.Web.Services.Description.ServiceDescriptionCollection.CopyTo()

/* The following program demonstrates 'Item' property, 'Insert' and 'CopyTo'
   methods of the 'ServiceDescriptionCollection' class. It creates an instance of
   'ServiceDescriptionCollection' and adds 'ServiceDescription' objects to the
   collection. The elements of the collection are copied to a 'ServiceDescription'
   array.

   Note: This program requires 'DataTypes_CS.wsdl' and 'MathService_CS.wsdl'
   files to be placed in the same directory as that of .exe for running.
*/
using System;
using System.Web.Services.Description;

class MyServiceDescriptionCollection
{
   public static void Main()
   {
      try
      {
         ServiceDescription myServiceDescription1 = ServiceDescription.Read("DataTypes_CS.wsdl");
         myServiceDescription1.Name = "DataTypes";
         ServiceDescription myServiceDescription2 = ServiceDescription.Read("MathService_CS.wsdl");
         myServiceDescription2.Name = "MathService";

         // Create the object of 'ServiceDescriptionCollection' class.
         ServiceDescriptionCollection myCollection = new ServiceDescriptionCollection();
         // Add 'ServiceDescription' objects.
         myCollection.Add(myServiceDescription1) ;
// <Snippet11>
         // Insert a ServiceDescription into the collection.
         myCollection.Insert(1, myServiceDescription2);
// </Snippet11>
// <Snippet12>
          // Get a ServiceDescription from the collection using
          // the Item property.
          ServiceDescription myServiceDescription =
             myCollection["http://tempuri1.org/"];
// </Snippet12>
         Console.WriteLine("Name of object retrieved using 'Item' property: "
            + myServiceDescription.Name);
// <Snippet13>
         ServiceDescription[] myArray =
            new ServiceDescription[myCollection.Count];

         // Copy the collection to a ServiceDescription array.
         myCollection.CopyTo(myArray,0);
         for(int i = 0; i < myArray.Length; i++)
         {
            Console.WriteLine("Name of element in array: " +
               myArray[i].Name);
         }
// </Snippet13>
      }
      catch(Exception e)
      {
         Console.WriteLine("The following exception was raised: {0}", e.Message);
      }
   }
}
