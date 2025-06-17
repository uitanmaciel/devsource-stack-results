using DevSource.Stack.Results.StatusCodeTypes;
using System.Collections.Generic;

namespace DevSource.Stack.Results.Abstractions;

public interface IRedirectStatus
{
    RedirectType RedirectType { get; }
    IList<string> Messages { get; }
}
