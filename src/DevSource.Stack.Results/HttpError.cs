using DevSource.Stack.Results.Abstractions;
using DevSource.Stack.Results.StatusCodeTypes;
using System.Collections.Generic;

namespace DevSource.Stack.Results;

public sealed class HttpError : IErrorStatus
{
    public ErrorType ErrorType { get; }
    public IList<string> Messages { get; }

    // Constructor used by static properties to create instances for the map
    // Made public as the class is now public.
    public HttpError(ErrorType errorType, IList<string>? messages)
    {
        ErrorType = errorType;
        Messages = messages ?? new List<string>();
    }
    
    public static HttpError GetError(ErrorType errorType) // Returns concrete HttpError
    {
        if(ErrorMap.TryGetValue(errorType, out var error)) return error;
        throw new ArgumentOutOfRangeException(nameof(errorType), errorType, null);
    }

    private static readonly Dictionary<ErrorType, HttpError> ErrorMap = new()
    {
        [ErrorType.BadRequest] = BadRequest,
        [ErrorType.Unauthorized] = Unauthorized,
        [ErrorType.PaymentRequired] = PaymentRequired,
        [ErrorType.Forbidden] = Forbidden,
        [ErrorType.NotFound] = NotFound,
        [ErrorType.MethodNotAllowed] = MethodNotAllowed,
        [ErrorType.NotAcceptable] = NotAcceptable,
        [ErrorType.ProxyAuthenticationRequired] = ProxyAuthenticationRequired,
        [ErrorType.RequestTimeout] = RequestTimeout,
        [ErrorType.Conflict] = Conflict,
        [ErrorType.Gone] = Gone,
        [ErrorType.LengthRequired] = LengthRequired,
        [ErrorType.PreconditionFailed] = PreconditionFailed,
        [ErrorType.PayloadTooLarge] = PayloadTooLarge,
        [ErrorType.UriToLong] = UriToLong,
        [ErrorType.UnsupportedMediaType] = UnsupportedMediaType,
        [ErrorType.RangeNotSatisfiable] = RangeNotSatisfiable,
        [ErrorType.ExpectationFailed] = ExpectationFailed,
        [ErrorType.MisdirectedRequest] = MisdirectedRequest,
        [ErrorType.UnprocessableContent] = UnprocessableContent,
        [ErrorType.Locked] = Locked,
        [ErrorType.FailedDependency] = FailedDependency,
        [ErrorType.TooEarly] = TooEarly,
        [ErrorType.UpgradeRequired] = UpgradeRequired,
        [ErrorType.PreconditionRequired] = PreconditionRequired,
        [ErrorType.TooManyRequests] = TooManyRequests,
        [ErrorType.RequestHeaderFieldsTooLarge] = RequestHeaderFieldsTooLarge,
        [ErrorType.UnavailableForLegalReasons] = UnavailableForLegalReasons,
        [ErrorType.InternalServerError] = InternalServerError,
        [ErrorType.NotImplemented] = NotImplemented,
        [ErrorType.BadGateway] = BadGateway,
        [ErrorType.ServiceUnavailable] = ServiceUnavailable,
        [ErrorType.GatewayTimeout] = GatewayTimeout,
        [ErrorType.HttpVersionNotSupported] = HttpVersionNotSupported,
        [ErrorType.VariantAlsoNegotiates] = VariantAlsoNegotiates,
        [ErrorType.InsufficientStorage] = InsufficientStorage,
        [ErrorType.LoopDetected] = LoopDetected,
        [ErrorType.NotExtended] = NotExtended,
        [ErrorType.NetworkAuthenticationRequired] = NetworkAuthenticationRequired
    };
    
    private static HttpError BadRequest
        => new(ErrorType.BadRequest, new List<string>
        {
            "Your request could not be understood due to malformed syntax."
        });

    private static HttpError Unauthorized
        => new(ErrorType.Unauthorized, new List<string>
        {
            "Authentication is required and has failed or has not been provided."
        });

    private static HttpError PaymentRequired
        => new(ErrorType.PaymentRequired, new List<string>
        {
            "Payment is required to access this resource."
        });

    private static HttpError Forbidden
        => new(ErrorType.Forbidden, new List<string>
        {
            "You do not have the necessary permissions to access this resource."
        });

    private static HttpError NotFound
        => new(ErrorType.NotFound, new List<string>
        {
            "The requested resource could not be found."
        });

    private static HttpError MethodNotAllowed
        => new(ErrorType.MethodNotAllowed, new List<string>
        {
            "The method specified in the request is not allowed for the resource identified."
        });

    private static HttpError NotAcceptable
        => new(ErrorType.NotAcceptable, new List<string>
        {
            "The resource is capable of generating only content not acceptable according to the Accept headers sent in the request."
        });

    private static HttpError ProxyAuthenticationRequired
        => new(ErrorType.ProxyAuthenticationRequired, new List<string>
        {
            "You must authenticate with a proxy server before this request can be served."
        });

    private static HttpError RequestTimeout
        => new(ErrorType.RequestTimeout, new List<string>
        {
            "The server timed out waiting for the request."
        });

    private static HttpError Conflict
        => new(ErrorType.Conflict, new List<string>
        {
            "The request could not be completed due to a conflict with the current state of the resource." 
        });

    private static HttpError Gone
        => new(ErrorType.Gone, new List<string>
        {
            "The requested resource is no longer available at the server and no forwarding address is known."
        });

    private static HttpError LengthRequired
        => new(ErrorType.LengthRequired, new List<string>
        {
            "The request did not specify the length of its content, which is required by the requested resource."
        });

    private static HttpError PreconditionFailed
        => new(ErrorType.PreconditionFailed, new List<string>
        {
            "One or more preconditions given in the request header fields evaluated to false when tested on the server."
        });

    private static HttpError PayloadTooLarge
        => new(ErrorType.PayloadTooLarge, new List<string>
        {
            "The server is refusing to process a request because the request payload is larger than the server is willing or able to process."
        });

    private static HttpError UriToLong
        => new(ErrorType.UriToLong, new List<string>
        {
            "The URI provided was too long for the server to process."
        });

    private static HttpError UnsupportedMediaType
        => new(ErrorType.UnsupportedMediaType,new List<string>
        {
            "The server is refusing to service the request because the entity of the request is in a format not supported by the requested resource for the requested method."
        });

    private static HttpError RangeNotSatisfiable
        => new(ErrorType.RangeNotSatisfiable, new List<string>
        {
            "The server cannot serve the requested ranges."
        });

    private static HttpError ExpectationFailed
        => new(ErrorType.ExpectationFailed, new List<string>
        {
            "The server cannot meet the requirements of the Expect request-header field."
        });

    private static HttpError MisdirectedRequest
        => new(ErrorType.MisdirectedRequest, new List<string>
        {
            "The request was directed at a server that is not able to produce a response."
        });

    private static HttpError UnprocessableContent
        => new(ErrorType.UnprocessableContent, new List<string>
        {
            "The server understands the content type of the request entity, but was unable to process the contained instructions."
        });

    private static HttpError Locked
        => new(ErrorType.Locked, new List<string>
        {
            "The resource that is being accessed is locked."
        });

    private static HttpError FailedDependency
        => new(ErrorType.FailedDependency, new List<string>
        {
            "The request failed due to the failure of a previous request."
        });

    private static HttpError TooEarly
        => new(ErrorType.TooEarly, new List<string>
        {
            "The server is unwilling to risk processing a request that might be replayed."
        });

    private static HttpError UpgradeRequired
        => new(ErrorType.UpgradeRequired, new List<string>
        {
            "The client should switch to a different protocol."
        });

    private static HttpError PreconditionRequired
        => new(ErrorType.PreconditionRequired, new List<string>
        {
            "The server requires the request to be conditional."
        });

    private static HttpError TooManyRequests
        => new(ErrorType.TooManyRequests, new List<string>
        {
            "You have sent too many requests in a given amount of time."
        });

    private static HttpError RequestHeaderFieldsTooLarge
        => new(ErrorType.RequestHeaderFieldsTooLarge, new List<string>
        {
            "The server is unwilling to process the request because its header fields are too large."
        });

    private static HttpError UnavailableForLegalReasons
        => new(ErrorType.UnavailableForLegalReasons, new List<string>
        {
            "The requested resource is unavailable due to legal reasons."
        });

    private static HttpError InternalServerError
        => new(ErrorType.InternalServerError, new List<string>
        {
            "The server encountered an unexpected condition that prevented it from fulfilling the request."
        });

    private static HttpError NotImplemented
        => new(ErrorType.NotImplemented, new List<string>
        {
            "The server does not support the functionality required to fulfill the request."
        });

    private static HttpError BadGateway
        => new(ErrorType.BadGateway, new List<string>
        {
            "The server received an invalid response from the upstream server."
        });

    private static HttpError ServiceUnavailable
        => new(ErrorType.ServiceUnavailable, new List<string>
        {
            "The server is currently unable to handle the request due to a temporary overloading or maintenance of the server."
        });

    private static HttpError GatewayTimeout
        => new(ErrorType.GatewayTimeout, new List<string>
        {
            "The upstream server failed to send a request in the time allowed by the server."
        });

    private static HttpError HttpVersionNotSupported
        => new(ErrorType.HttpVersionNotSupported, new List<string>
        {
            "The server does not support the HTTP protocol version that was used in the request."
        });

    private static HttpError VariantAlsoNegotiates
        => new(ErrorType.VariantAlsoNegotiates, new List<string>
        {
            "The server has an internal configuration error: the chosen variant resource is configured to engage in transparent content negotiation and is therefore not a " +
            "suitable endpoint in the negotiation process."
        });

    private static HttpError InsufficientStorage
        => new(ErrorType.InsufficientStorage, new List<string>
        {
            "The server is unable to store the representation needed to complete the request."
        });

    private static HttpError LoopDetected
        => new(ErrorType.LoopDetected, new List<string>
        {
            "The server detected an infinite loop while processing the request."
        });

    private static HttpError NotExtended
        => new(ErrorType.NotExtended, new List<string>
        {
            "Further extensions to the request are required for the server to fulfill it."
        });

    private static HttpError NetworkAuthenticationRequired
        => new(ErrorType.NetworkAuthenticationRequired, new List<string>
        {
            "The client needs to authenticate to gain network access."
        });

    public override string ToString()
        => $"{ErrorType}: {Messages}";
}