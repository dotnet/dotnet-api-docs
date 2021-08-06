// <snippet9>
using System;

public class IsPunctuationSample {
	public static void Main() {
		char ch = '.';

		Console.WriteLine(char.IsPunctuation(ch));						// Output: "True"
		Console.WriteLine(char.IsPunctuation("no punctuation", 3));		// Output: "False"
	}
}
// </snippet9>
