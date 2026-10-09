using System;

namespace SystemByte_Examples
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class Class1
    {
        static void Main(string[] args)
        {
            SystemByteExamples sbe = new();
            int numberToSet;
            byte compareByte;
            //         String stringToConvert;

            numberToSet = 120;
            //         stringToConvert = "200";
            compareByte = 201;

            sbe.MinMaxFields(numberToSet);
            sbe.ParseByte();

            sbe.Compare(compareByte);
        }
    }

    class SystemByteExamples
    {
        private byte MemberByte;

        // c'tor()
        public SystemByteExamples() => MemberByte = 0;

        // The following example demonstrates using the MinValue and MaxValue fields to
        //  determine whether an integer value falls within range of a byte.  If it does,
        //  the value is set.  If not, an error message is displayed.

        // MemberByte is assumed to exist as a class member.

        //<Snippet1>
        public void MinMaxFields(int numberToSet)
        {
            if (numberToSet <= (int)byte.MaxValue && numberToSet >= (int)byte.MinValue)
            {
                // You must explicitly convert an integer to a byte.
                MemberByte = (byte)numberToSet;

                // Displays MemberByte using the ToString() method.
                Console.WriteLine($"The MemberByte value is {MemberByte.ToString()}");
            }
            else
            {
                Console.WriteLine($"The value {numberToSet.ToString()} is outside of the range of possible Byte values");
            }
        }
        //</Snippet1>

        // The following example converts the string representation of a byte
        //  into its actual numeric value.

        // MemberByte is assumed to exist as a class member.

        public void ParseByte()
        {
            // <Snippet2>
            string stringToConvert = " 162";
            byte byteValue;

            try
            {
                byteValue = byte.Parse(stringToConvert);
                Console.WriteLine($"The byte value is {byteValue.ToString()}.");
            }
            catch (System.OverflowException e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
            //</Snippet2>
        }

        // The following example checks to see whether a byte passed in is
        //  greater than, less than, or equal to the member byte.

        // MemberByte is assumed to exist as a class member.

        //<Snippet3>
        public void Compare(byte myByte)
        {
            int myCompareResult;

            myCompareResult = MemberByte.CompareTo(myByte);

            if (myCompareResult > 0)
            {
                Console.WriteLine($"{myByte.ToString()} is less than the MemberByte value {MemberByte.ToString()}");
            }
            else if (myCompareResult < 0)
            {
                Console.WriteLine($"{myByte.ToString()} is greater than the MemberByte value {MemberByte.ToString()}");
            }
            else
            {
                Console.WriteLine($"{myByte.ToString()} is equal to the MemberByte value {MemberByte.ToString()}");
            }
        }
        //</Snippet3>
    }
}
