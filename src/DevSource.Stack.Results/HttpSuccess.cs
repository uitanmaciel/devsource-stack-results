using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results;

internal sealed class HttpSuccess(SuccessType successType, IList<string>? messages)
{
    public SuccessType SuccessType { get; } = successType;
    public IList<string>? Messages { get; } = messages ?? [];
    
    public static HttpSuccess GetSuccess(SuccessType successType)
    {
        if (SuccessMap.TryGetValue(successType, out var success)) return success;
        throw new ArgumentOutOfRangeException(nameof(successType), successType, null);
    }

    private static readonly Dictionary<SuccessType, HttpSuccess> SuccessMap = new()
    {
        [SuccessType.Ok] = Ok,
        [SuccessType.Created] = Created,
        [SuccessType.Accepted] = Accepted,
        [SuccessType.NonAuthoritativeInformation] = NonAuthoritativeInformation,
        [SuccessType.NoContent] = NoContent,
        [SuccessType.ResetContent] = ResetContent,
        [SuccessType.PartialContent] = PartialContent,
        [SuccessType.MultiStatus] = MultiStatus,
        [SuccessType.AlreadyReported] = AlreadyReported,
        [SuccessType.IMUsed] = IMUsed
    };

    private static HttpSuccess Ok =>
        new HttpSuccess(SuccessType.Ok, new List<string>
        {
            "The request has succeeded."
        });

    private static HttpSuccess Created =>
        new HttpSuccess(SuccessType.Created, new List<string>
        {
            "The request has been fulfilled and a new resource has been created."
        });

    private static HttpSuccess Accepted =>
        new HttpSuccess(SuccessType.Accepted, new List<string>
        {
            "The request has been accepted for processing, but the processing has not been completed."
        });

    private static HttpSuccess NonAuthoritativeInformation =>
        new HttpSuccess(SuccessType.NonAuthoritativeInformation, new List<string>
        {
            "The response has been successfully received, but it is from a third-party source."
        });

    private static HttpSuccess NoContent =>
        new HttpSuccess(SuccessType.NoContent, new List<string>
        {
            "The response has been successfully received, but there is no content to send in the response."
        });

    private static HttpSuccess ResetContent =>
        new HttpSuccess(SuccessType.ResetContent, new List<string>
        {
            "The response has been successfully received, but the client should reset the document view."
        });

    private static HttpSuccess PartialContent =>
        new HttpSuccess(SuccessType.PartialContent, new List<string>
        {
            "The server has successfully fulfilled the partial GET request."
        });

    private static HttpSuccess MultiStatus =>
        new HttpSuccess(SuccessType.MultiStatus, new List<string>
        {
            "The response has multiple status codes."
        });
    
    private static HttpSuccess AlreadyReported =>
        new HttpSuccess(SuccessType.AlreadyReported, new List<string>
        {
            "The response has been successfully received, but the response has been already reported."
        });
    
    private static HttpSuccess IMUsed =>
        new HttpSuccess(SuccessType.IMUsed, new List<string>
        {
            "The response has been successfully received, but the response has been already reported."
        });
}