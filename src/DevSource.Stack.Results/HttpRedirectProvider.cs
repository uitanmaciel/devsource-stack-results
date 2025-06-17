using DevSource.Stack.Results.Abstractions;
using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results;

public class HttpRedirectProvider : IHttpRedirectProvider
{
    public IRedirectStatus GetRedirect(RedirectType redirectType)
    {
        return HttpRedirect.GetRedirect(redirectType);
    }
}
