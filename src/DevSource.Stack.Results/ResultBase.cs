using System.Text.Json.Serialization;

namespace DevSource.Stack.Results;

public abstract class ResultBase
{
    [JsonIgnore] 
    public bool IsSuccess => StatusCode is >= 200 and < 300;
    
    [JsonPropertyName("statusCode")] 
    public int? StatusCode { get; init; }
    
    [JsonPropertyName("messages")]
    public IList<string>? Messages { get; init; }
}