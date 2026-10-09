// <Snippet2>
using System;
using System.Diagnostics.Contracts;

namespace ContractArgumentValidatorSnippet2;

static class ValidationHelper
{
    [ContractArgumentValidator]
    public static void NotNull(object argument, string parameterName)
    {
        if (argument is null)
        {
            throw new ArgumentNullException(parameterName, "The parameter cannot be null.");
        }

        Contract.EndContractBlock();
    }
}
// </Snippet2>

public class Example
{
    public void Execute(string value)
    {
        ValidationHelper.NotNull(value, "value");

        // Body of method goes here.
    }
}
