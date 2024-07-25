using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results;

internal sealed class HttpInformative(InformativeType informativeType, string? message)
{
    public InformativeType InformativeType { get; } = informativeType;
    public string? Message { get; } = message;
    
    public static HttpInformative GetInformative(InformativeType informativeType) 
        => informativeType switch
        {
            InformativeType.Continue => Continue,
            InformativeType.SwitchingProtocols => SwitchingProtocols,
            InformativeType.Processing => Processing,
            InformativeType.EarlyHints => EarlyHints,
            _ => throw new ArgumentOutOfRangeException(nameof(informativeType), informativeType, null)
        };
    
    private static HttpInformative Continue =>
        new HttpInformative(InformativeType.Continue,
            "The server received the request headers. Continue or ignore the response if the request has already been completed.");
    
    private static HttpInformative SwitchingProtocols =>
        new HttpInformative(InformativeType.SwitchingProtocols, "The server is changing protocols.");
    
    private static HttpInformative Processing =>
        new HttpInformative(InformativeType.Processing, "The server is processing the request, but no response is available yet.");
    
    private static HttpInformative EarlyHints =>
        new HttpInformative(InformativeType.EarlyHints, "The server is sending a response with some headers, but the final response is not yet available.");

    public override string ToString() => $"{(int)InformativeType}: {Message}";
}