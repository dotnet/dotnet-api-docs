// <Snippet1>
using System;
using System.Security.Cryptography;
using System.Text;

class MainClass
{
	public static void Main()
	{
		RandomNumberGenerator rnd = RandomNumberGenerator.Create();

		byte[] input = new byte[20];
		rnd.GetBytes(input);

		Console.WriteLine("Input        : {0}\n", BytesToStr(input));
		PrintHash(input);
		PrintHashOneBlock(input);
		PrintHashMultiBlock(input, 1);
		PrintHashMultiBlock(input, 2);
		PrintHashMultiBlock(input, 3);
		PrintHashMultiBlock(input, 5);
		PrintHashMultiBlock(input, 10);
		PrintHashMultiBlock(input, 11);
		PrintHashMultiBlock(input, 19);
		PrintHashMultiBlock(input, 20);
		PrintHashMultiBlock(input, 21);
	}

	public static string BytesToStr(byte[] bytes)
	{
		StringBuilder str = new StringBuilder();

		for (int i = 0; i < bytes.Length; i++)
			str.AppendFormat("{0:X2}", bytes[i]);

		return str.ToString();
	}

	public static void PrintHash(byte[] input)
	{
		SHA256Managed sha = new SHA256Managed();
		Console.WriteLine("ComputeHash  : {0}", BytesToStr(sha.ComputeHash(input)));
	}

	public static void PrintHashOneBlock(byte[] input)
	{
		SHA256Managed sha = new SHA256Managed();
		sha.TransformFinalBlock(input, 0, input.Length);
		Console.WriteLine("FinalBlock   : {0}", BytesToStr(sha.Hash));
	}

	public static void PrintHashMultiBlock(byte[] input, int size)
	{
		SHA256Managed sha = new SHA256Managed();
		int offset = 0;

		while (input.Length - offset >= size)
			offset += sha.TransformBlock(input, offset, size, input, offset);

		sha.TransformFinalBlock(input, offset, input.Length - offset);
		Console.WriteLine("MultiBlock {0:00}: {1}", size, BytesToStr(sha.Hash));
	}
}
/*
This example produces output similar to the following:

Input        : 45D97219908A572DE336B9DEC787C311D3349F69

ComputeHash  : 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
FinalBlock   : 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
MultiBlock 01: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
MultiBlock 02: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
MultiBlock 03: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
MultiBlock 05: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
MultiBlock 10: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
MultiBlock 11: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
MultiBlock 19: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
MultiBlock 20: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
MultiBlock 21: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15

*/
// </Snippet1>