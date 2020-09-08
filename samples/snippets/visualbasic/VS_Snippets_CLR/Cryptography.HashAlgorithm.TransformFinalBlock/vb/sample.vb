'<Snippet1>

Imports System.Text
Imports System.Security.Cryptography

Class Program

	Public Shared Sub Main()
		Dim rnd As RandomNumberGenerator = RandomNumberGenerator.Create
		Dim input() As Byte = New Byte((20) - 1) {}
		rnd.GetBytes(input)
		Console.WriteLine("Input        : {0}"& vbLf, BytesToStr(input))
		PrintHash(input)
		PrintHashOneBlock(input)
		PrintHashMultiBlock(input, 1)
		PrintHashMultiBlock(input, 2)
		PrintHashMultiBlock(input, 3)
		PrintHashMultiBlock(input, 5)
		PrintHashMultiBlock(input, 10)
		PrintHashMultiBlock(input, 11)
		PrintHashMultiBlock(input, 19)
		PrintHashMultiBlock(input, 20)
		PrintHashMultiBlock(input, 21)
	End Sub

	Public Shared Function BytesToStr(ByVal bytes() As Byte) As String
		Dim str As StringBuilder = New StringBuilder
		Dim i As Integer = 0
		Do While (i < bytes.Length)
		str.AppendFormat("{0:X2}", bytes(i))
		i = (i + 1)
		Loop
		Return str.ToString
	End Function

	Public Shared Sub PrintHash(ByVal input() As Byte)
		Dim sha As SHA256Managed = New SHA256Managed
		Console.WriteLine("ComputeHash  : {0}", BytesToStr(sha.ComputeHash(input)))
	End Sub

	Public Shared Sub PrintHashOneBlock(ByVal input() As Byte)
		Dim sha As SHA256Managed = New SHA256Managed
		sha.TransformFinalBlock(input, 0, input.Length)
		Console.WriteLine("FinalBlock   : {0}", BytesToStr(sha.Hash))
	End Sub

	Public Shared Sub PrintHashMultiBlock(ByVal input() As Byte, ByVal size As Integer)
		Dim sha As SHA256Managed = New SHA256Managed
		Dim offset As Integer = 0

		While ((input.Length - offset)  _
			>= size)
		offset = (offset + sha.TransformBlock(input, offset, size, input, offset))

		End While
		sha.TransformFinalBlock(input, offset, (input.Length - offset))
		Console.WriteLine("MultiBlock {0:00}: {1}", size, BytesToStr(sha.Hash))
	End Sub
End Class

' This example produces output similar to the following:
'
' Input        : 45D97219908A572DE336B9DEC787C311D3349F69
'
' ComputeHash  : 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' FinalBlock   : 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' MultiBlock 01: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' MultiBlock 02: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' MultiBlock 03: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' MultiBlock 05: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' MultiBlock 10: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' MultiBlock 11: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' MultiBlock 19: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' MultiBlock 20: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' MultiBlock 21: 84E87322C7E3BCA848B0A698EE66E9A9725DA786F9FD4FFD46C385F59AB35B15
' </Snippet1>
