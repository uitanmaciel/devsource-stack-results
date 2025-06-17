using DevSource.Stack.Results.Abstractions;
using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results;

public class HttpSuccessProvider : IHttpSuccessProvider
{
    public ISuccessStatus GetSuccess(SuccessType successType)
    {
        return HttpSuccess.GetSuccess(successType);
    }
}
