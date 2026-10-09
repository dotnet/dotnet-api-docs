// <Snippet1>
using System;
using System.Runtime.Serialization;

[Serializable()]
public class NotPrimeException : Exception
{
    private int notAPrime;

    protected NotPrimeException()
       : base()
    { }

    public NotPrimeException(int value) :
       base($"{value} is not a prime number.") => notAPrime = value;

    public NotPrimeException(int value, string message)
       : base(message) => notAPrime = value;

    public NotPrimeException(int value, string message, Exception innerException) :
       base(message, innerException) => notAPrime = value;

    protected NotPrimeException(SerializationInfo info,
                                StreamingContext context)
       : base(info, context)
    { }

    public int NonPrime => notAPrime;
}
// </Snippet1>
