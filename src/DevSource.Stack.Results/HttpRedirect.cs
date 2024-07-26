using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results;

internal sealed class HttpRedirect(RedirectType redirectType, string? message)
{
    public RedirectType RedirectType { get; } = redirectType;
    public string? Message { get; } = message;
    
    public static HttpRedirect GetRedirect(RedirectType redirectType) 
    {
        if (RedirectMap.TryGetValue(redirectType, out var redirect)) return redirect;
        throw new ArgumentOutOfRangeException(nameof(redirectType), redirectType, null);
    }
    
    private static Dictionary<RedirectType, HttpRedirect> RedirectMap { get; } = new()
    {
        [RedirectType.MultipleChoices] = MultipleChoices,
        [RedirectType.MovedPermanently] = MovedPermanently,
        [RedirectType.Found] = Found,
        [RedirectType.SeeOther] = SeeOther,
        [RedirectType.NotModified] = NotModified,
        [RedirectType.TemporaryRedirect] = TemporaryRedirect,
        [RedirectType.PermanentRedirect] = PermanentRedirect
    };
    
    private static HttpRedirect MultipleChoices =>
        new HttpRedirect(RedirectType.MultipleChoices, "The request has more than one possible response. The user-agent or the user should choose one of them.");
    
    private static HttpRedirect MovedPermanently =>
        new HttpRedirect(RedirectType.MovedPermanently, "The requested resource has been assigned a new permanent URI and any future references to this resource should use one of the returned URIs.");
    
    private static HttpRedirect Found =>
        new HttpRedirect(RedirectType.Found, "The requested resource resides temporarily under a different URI.");
    
    private static HttpRedirect SeeOther =>
        new HttpRedirect(RedirectType.SeeOther, "The response to the request can be found under a different URI and should be retrieved using a GET method.");
    
    private static HttpRedirect NotModified =>
        new HttpRedirect(RedirectType.NotModified, "The resource has not been modified since the version specified by the request headers If-Modified-Since or If-None-Match.");
    
    private static HttpRedirect TemporaryRedirect =>
        new HttpRedirect(RedirectType.TemporaryRedirect, "The requested resource resides temporarily under a different URI.");
    
    private static HttpRedirect PermanentRedirect =>
        new HttpRedirect(RedirectType.PermanentRedirect, "The requested resource has been assigned a new permanent URI and any future references to this resource should use one of the returned URIs.");
}