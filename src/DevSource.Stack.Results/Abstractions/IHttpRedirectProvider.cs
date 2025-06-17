using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results.Abstractions;

public interface IHttpRedirectProvider
{
    IRedirectStatus GetRedirect(RedirectType redirectType);
}
