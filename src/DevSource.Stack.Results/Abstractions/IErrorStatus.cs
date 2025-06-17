using DevSource.Stack.Results.StatusCodeTypes;
using System.Collections.Generic;

namespace DevSource.Stack.Results.Abstractions;

public interface IErrorStatus
{
    ErrorType ErrorType { get; }
    IList<string> Messages { get; }
}
