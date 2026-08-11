// <Snippet1>
using System;
using System.Text;

public class ConsoleKeyExample
{
   public static void Main()
   {
      ConsoleKeyInfo input;
      do {
         Console.WriteLine("Press a key, together with Alt, Ctrl, or Shift.");
         Console.WriteLine("Press Esc to exit.");
         input = Console.ReadKey(true);

         StringBuilder output = new StringBuilder(
                       String.Format("You pressed {0}", input.Key.ToString()));
         bool modifiers = false;

         if (input.Modifiers.HasFlag(ConsoleModifiers.Alt)) {
            output.Append(", together with " + ConsoleModifiers.Alt.ToString());
            modifiers = true;
         }
         if (input.Modifiers.HasFlag(ConsoleModifiers.Control))
         {
            if (modifiers) {
               output.Append(" and ");
            }
            else {
               output.Append(", together with ");
               modifiers = true;
            }
            output.Append(ConsoleModifiers.Control.ToString());
         }
         if (input.Modifiers.HasFlag(ConsoleModifiers.Shift))
         {
            if (modifiers) {
               output.Append(" and ");
            }
            else {
               output.Append(", together with ");
               modifiers = true;
            }
            output.Append(ConsoleModifiers.Shift.ToString());
         }
         output.Append(".");
         Console.WriteLine(output.ToString());
         Console.WriteLine();
      } while (input.Key != ConsoleKey.Escape);
   }
}
// The output from a sample console session might appear as follows:
//       Press a key, together with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed D.
//
//       Press a key, together with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed X, together with Shift.
//
//       Press a key, together with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed L, together with Control and Shift.
//
//       Press a key, together with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed P, together with Alt and Control and Shift.
//
//       Press a key, together with Alt, Ctrl, or Shift.
//       Press Esc to exit.
//       You pressed Escape.
// </Snippet1>
