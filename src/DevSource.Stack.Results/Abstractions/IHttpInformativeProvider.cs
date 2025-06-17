using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results.Abstractions;

public interface IHttpInformativeProvider
{
    IInformativeStatus GetInformative(InformativeType informativeType);
}
