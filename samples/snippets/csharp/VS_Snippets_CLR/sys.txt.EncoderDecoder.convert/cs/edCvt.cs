﻿//<snippet1>
// This code example demonstrates the Encoder.Convert() and Decoder.Convert methods.
// This example uses files for input and output, but any source that can be expressed
// as a stream can be used instead.

    using System;
    using System.Text;
    using System.IO;

    public class Sample
    {
    static void Main(string[] args)
        {
// Create a large file of UTF-16 encoded Unicode characters. The file is named Example.txt,
// and is used as input to the Encoder.Convert() method.

            CreateTestFile("Example.txt");

// Using an input file of UTF-16 encoded characters named Example.txt, create an output file
// of UTF-8 encoded bytes named UTF8.txt.

            EncoderConvert("Example.txt", "UTF8.txt", Encoding.UTF8);

// Using an input file of UTF-8 encoded bytes named UTF8.txt, create an output file
// of UTF-16 encoded characters named UTF16.txt.

            DecoderConvert("UTF8.txt", "UTF16.txt", Encoding.UTF8);
        }

// --------------------------------------------------------------------------------------------
// Use the Encoder.Convert() method to convert a file of characters to a file of encoded bytes.
// --------------------------------------------------------------------------------------------
        static void EncoderConvert(String inputFileName, String outputFileName, Encoding enc)
        {
// Convert an input file of characters to an output file of encoded bytes.
// StreamWriter could convert the input file for us, but we'll perform the conversion
// ourselves.

            FileStream fs = new FileStream(outputFileName, FileMode.Create);
            BinaryWriter outputFile = new BinaryWriter(fs);

// StreamReader will detect Unicode encoding from the Byte Order Mark that heads the input file.
            StreamReader inputFile = new StreamReader(inputFileName);

// Get an Encoder.
            Encoder encoder = enc.GetEncoder();

// Guarantee the output buffer large enough to convert a few characters.
            int UseBufferSize = 64;
            if (UseBufferSize < enc.GetMaxByteCount(10))
                    UseBufferSize = enc.GetMaxByteCount(10);
            byte[] bytes = new byte[UseBufferSize];

// Intentionally make the input character buffer larger than the output byte buffer so the
// conversion loop executes more than one cycle.

            char[] chars = new char[UseBufferSize * 4];
            int charsRead;
            do
            {
// Read at most the number of characters that will fit in the input buffer. The return
// value is the actual number of characters read, or zero if no characters remain.
                charsRead = inputFile.Read(chars, 0, UseBufferSize * 4);

                bool completed = false;
                int charIndex = 0;
                int charsUsed;
                int bytesUsed;

                while (!completed)
                {
// If this is the last input data, flush the encoder's internal buffer and state.

                    bool flush = (charsRead == 0);
                    encoder.Convert(chars, charIndex, charsRead - charIndex,
                                    bytes, 0, UseBufferSize, flush,
                                    out charsUsed, out bytesUsed, out completed);

// The conversion produced the number of bytes indicated by bytesUsed. Write that number
// of bytes to the output file.
                    outputFile.Write(bytes, 0, bytesUsed);

// Increment charIndex to the next block of characters in the input buffer, if any, to convert.
                    charIndex += charsUsed;
                }
            }
            while(charsRead != 0);

            outputFile.Close();
            fs.Close();
            inputFile.Close();
        }

// --------------------------------------------------------------------------------------------
// Use the Decoder.Convert() method to convert a file of encoded bytes to a file of characters.
// --------------------------------------------------------------------------------------------
        static void DecoderConvert(String inputFileName, String outputFileName, Encoding enc)
        {
// Convert an input file of of encoded bytes to an output file characters.
// StreamWriter could convert the input file for us, but we'll perform the conversion
// ourselves.

            StreamWriter outputFile = new StreamWriter(outputFileName, false, Encoding.Unicode);

// Read the input as a binary file so we can detect the Byte Order Mark.
            FileStream fs = new FileStream(inputFileName, FileMode.Open);
            BinaryReader inputFile = new BinaryReader(fs);

// Get a Decoder.
            Decoder decoder = enc.GetDecoder();

// Guarantee the output buffer large enough to convert a few characters.
            int UseBufferSize = 64;
            if (UseBufferSize < enc.GetMaxCharCount(10))
                    UseBufferSize = enc.GetMaxCharCount(10);
            char[] chars = new char[UseBufferSize];

// Intentionally make the input byte buffer larger than the output character buffer so the
// conversion loop executes more than one cycle.

            byte[] bytes = new byte[UseBufferSize * 4];
            int bytesRead;
            do
            {
// Read at most the number of bytes that will fit in the input buffer. The
// return value is the actual number of bytes read, or zero if no bytes remain.

                bytesRead = inputFile.Read(bytes, 0, UseBufferSize * 4);

                bool completed = false;
                int byteIndex = 0;
                int bytesUsed;
                int charsUsed;

                while (!completed)
                {
// If this is the last input data, flush the decoder's internal buffer and state.

                    bool flush = (bytesRead == 0);
                    decoder.Convert(bytes, byteIndex, bytesRead - byteIndex,
                                    chars, 0, UseBufferSize, flush,
                                    out bytesUsed, out charsUsed, out completed);

// The conversion produced the number of characters indicated by charsUsed. Write that number
// of characters to the output file.

                    outputFile.Write(chars, 0, charsUsed);

// Increment byteIndex to the next block of bytes in the input buffer, if any, to convert.
                    byteIndex += bytesUsed;
                }
            }
            while(bytesRead != 0);

            outputFile.Close();
            fs.Close();
            inputFile.Close();
        }

// --------------------------------------------------------------------------------------------
// Create a large file of UTF-16 encoded Unicode characters.
// --------------------------------------------------------------------------------------------
        static void CreateTestFile(String FileName)
        {
// StreamWriter defaults to UTF-8 encoding so explicitly specify Unicode, that is,
// UTF-16, encoding.
            StreamWriter file = new StreamWriter(FileName, false, Encoding.Unicode);

// Write a line of text 100 times.
            for (int i = 0; i < 100; i++)
            {
                file.WriteLine("This is an example input file used by the convert example.");
            }

// Write Unicode characters from U+0000 to, but not including, the surrogate character range.
            for (char c = (char)0; c < (char)0xD800; c++)
            {
                file.Write(c);
            }
            file.Close();
        }
    }

/*
This code example produces the following results:

(Execute the -dir- console window command and examine the files created.)

Example.txt, which contains 122,594 bytes (61,297 UTF-16 encoded characters).
UTF8.txt, which contains 169,712 UTF-8 encoded bytes.
UTF16.txt, which contains 122,594 bytes (61,297 UTF-16 encoded characters).

(Execute the -comp- console window command and compare the two Unicode files.)

>comp example.txt utf16.txt /L
Comparing example.txt and utf16.txt...
Files compare OK

(The two files are equal.)

*/
//</snippet1>