﻿// <Snippet3>
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;

public class Example
{
   public static void Main()
   {
      // Bitmap as stream
      MemoryStream bitmapStream = new MemoryStream();
      Bitmap bmp = new Bitmap(@".\\AppImage.jpg");
      bmp.Save(bitmapStream, ImageFormat.Jpeg);
          
      ResourceWriter rw = new ResourceWriter(@".\UIImages.resources");
      rw.AddResource("Bitmap", bitmapStream, true);
      // Add other resources.
      rw.Generate();
   }
}
// </Snippet3>
