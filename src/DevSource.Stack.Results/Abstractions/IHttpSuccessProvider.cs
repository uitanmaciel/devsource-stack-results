using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results.Abstractions;

public interface IHttpSuccessProvider
{
    ISuccessStatus GetSuccess(SuccessType successType);
}
