// <snippet5>
using System;

public class IsLetterSample {
	public static void Main() {
		char ch = '8';

		Console.WriteLine(char.IsLetter(ch));					// False
		Console.WriteLine(char.IsLetter("sample string", 7));	// True
	}
}
// </snippet5>
