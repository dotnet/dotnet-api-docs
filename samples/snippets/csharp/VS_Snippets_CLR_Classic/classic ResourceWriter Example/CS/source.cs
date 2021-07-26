// <Snippet1>
using System;
using System.Resources;

public class WriteResources {
   public static void Main(string[] args) {

      // Creates a resource writer.
      IResourceWriter writer = new ResourceWriter("myResources.resources");

      // Adds resources to the resource writer.
      writer.AddResource("string 1", "First string");

      writer.AddResource("string 2", "Second string");

      writer.AddResource("string 3", "Third string");

      // Writes the resources to the file or stream, and closes it.
      writer.Close();
   }
}
// </Snippet1>
