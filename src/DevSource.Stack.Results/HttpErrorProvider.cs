using DevSource.Stack.Results.Abstractions;
using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results;

public class HttpErrorProvider : IHttpErrorProvider
{
    public IErrorStatus GetError(ErrorType errorType)
    {
        // HttpError.GetError now returns a concrete HttpError, which implements IErrorStatus.
        return HttpError.GetError(errorType);
    }
}
