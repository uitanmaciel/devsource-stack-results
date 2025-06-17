using DevSource.Stack.Results.StatusCodeTypes;
using System.Collections.Generic;

namespace DevSource.Stack.Results.Abstractions;

public interface ISuccessStatus
{
    SuccessType SuccessType { get; }
    IList<string> Messages { get; }
}
