using DevSource.Stack.Results.Abstractions;
using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results;

public class HttpInformativeProvider : IHttpInformativeProvider
{
    public IInformativeStatus GetInformative(InformativeType informativeType)
    {
        return HttpInformative.GetInformative(informativeType);
    }
}
