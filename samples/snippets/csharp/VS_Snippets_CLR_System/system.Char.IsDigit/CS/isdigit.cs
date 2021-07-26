// <snippet4>
using System;

public class IsDigitSample {
	public static void Main() {
		char ch = '8';

		Console.WriteLine(char.IsDigit(ch));					// Output: "True"
		Console.WriteLine(char.IsDigit("sample string", 7));	// Output: "False"
	}
}
// </snippet4>
