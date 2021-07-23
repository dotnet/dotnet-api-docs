// <Snippet2>
using System;

public class TestAction3
{
   public static void Main()
   {
      string[] ordinals = {"First", "Second", "Third", "Fourth", "Fifth"};
      string[] copiedOrdinals = new string[ordinals.Length];
      Action<string[], string[], int> copyOperation = CopyStrings;
      copyOperation(ordinals, copiedOrdinals, 3);
      foreach (string ordinal in copiedOrdinals)
         Console.WriteLine(string.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);
   }

   private static void CopyStrings(string[] source, string[] target, int startPos)
   {
      if (source.Length != target.Length)
         throw new IndexOutOfRangeException("The source and target arrays must have the same number of elements.");

      for (int ctr = startPos; ctr <= source.Length - 1; ctr++)
         target[ctr] = string.Copy(source[ctr]);
   }
}
// </Snippet2>
