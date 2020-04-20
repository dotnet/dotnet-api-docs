﻿// <Snippet1>
using System;
using System.IO;

delegate bool WriteMethod();

public class TestDelegate
{
   public static void Main()
   {
      OutputTarget output = new OutputTarget();
      WriteMethod methodCall = output.SendToFile;
      if (methodCall())
         Console.WriteLine("Success!");
      else
         Console.WriteLine("File write operation failed.");
   }
}

public class OutputTarget
{
   public bool SendToFile()
   {
      try
      {
         string fn = Path.GetTempFileName();
         StreamWriter sw = new StreamWriter(fn);
         sw.WriteLine("Hello, World!");
         sw.Close();
         return true;
      }
      catch
      {
         return false;
      }
   }
}
// </Snippet1>
