using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results.Abstractions;

public interface IHttpErrorProvider
{
    IErrorStatus GetError(ErrorType errorType);
}
