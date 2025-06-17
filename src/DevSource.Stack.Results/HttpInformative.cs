using DevSource.Stack.Results.Abstractions;
using DevSource.Stack.Results.StatusCodeTypes;
using System.Collections.Generic;

namespace DevSource.Stack.Results;

public sealed class HttpInformative : IInformativeStatus
{
    public InformativeType InformativeType { get; }
    public string Message { get; } // Changed from string?

    // IInformativeStatus implementation
    public IList<string> Messages => new List<string> { Message };

    // Constructor made public, message parameter changed to non-nullable
    public HttpInformative(InformativeType informativeType, string message)
    {
        InformativeType = informativeType;
        Message = message;
    }

    public static HttpInformative GetInformative(InformativeType informativeType) // Returns concrete HttpInformative
    {
        if(InformativeMap.TryGetValue(informativeType, out var informative)) return informative;
        throw new ArgumentOutOfRangeException(nameof(informativeType), informativeType, null);
    }
    
    private static readonly Dictionary<InformativeType, HttpInformative> InformativeMap = new()
    {
        [InformativeType.Continue] = Continue,
        [InformativeType.SwitchingProtocols] = SwitchingProtocols,
        [InformativeType.Processing] = Processing,
        [InformativeType.EarlyHints] = EarlyHints
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