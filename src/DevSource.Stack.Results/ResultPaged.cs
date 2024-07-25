using System.Text.Json.Serialization;
using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results;

public class ResultPaged<TData> : ResultBase
{
    [JsonPropertyName("count")] public int Count { get; init; }
    [JsonPropertyName("currentPage")] public int? Page { get; init; }
    [JsonPropertyName("nextPage")] public string? NextPage { get; init; } = null!;
    [JsonPropertyName("previousPage")] public string? PreviousPage { get; init; } = null!;
    [JsonPropertyName("data")] public TData? Data { get; init; }
    [JsonIgnore] public int? PageSize { get; init; }
    [JsonIgnore] public int TotalPages => (int)Math.Ceiling(Count / (double)PageSize!);
    
    public ResultPaged(int? statusCode, int count, int? page, int? pageSize, TData? data, string? nextPage = null, string? previousPage = null, IList<string>? message = null)
    {
        StatusCode = statusCode;
        Count = count;
        Page = page;
        PageSize = pageSize;
        Data = data;
        NextPage = nextPage ?? string.Empty;
        PreviousPage = previousPage ?? string.Empty;
        Messages = message;
    }
    
    /// <summary>
    /// Creates a paginated failure result with the specified error type and optional error messages.
    /// </summary>
    /// <typeparam name="TData">
    /// The type of data that the result may contain. In this case, it will be <c>default</c> as the result represents a failure.
    /// </typeparam>
    /// <param name="errorType">The type of error to create a failure result for.</param>
    /// <param name="message">
    /// An optional list of custom error messages. If not provided, the default error messages for the error type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="ResultPaged{TData}"/> instance representing the failure, including the status code, an empty data collection, and the corresponding error messages.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default error messages associated with the specified <paramref name="errorType"/> from the <see cref="HttpError"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// The method returns a <see cref="ResultPaged{TData}"/> instance containing the status code of the error type, 
    /// with the data part set to <c>default</c> and the page details set to <c>null</c> as the result represents a failure.
    /// </remarks>
    public static ResultPaged<TData> Failure(ErrorType errorType, IList<string>? message = null)
    {
        var error = HttpError.GetError(errorType);
        return new ResultPaged<TData>(
            statusCode: (int)error.ErrorType, 
            count: 0, 
            page: null, 
            pageSize: null, 
            data: default, 
            nextPage: null, 
            previousPage: null, 
            message: error.Messages!.Select(errorMessage => errorMessage).ToList());
    }
    
    /// <summary>
    /// Creates a paginated informative result with the specified informative type and optional messages.
    /// </summary>
    /// <typeparam name="TData">
    /// The type of data that the result may contain. In this case, it will be <c>default</c> as the result represents an informative response.
    /// </typeparam>
    /// <param name="informativeType">The type of informative response to create a result for.</param>
    /// <param name="message">
    /// An optional list of custom informative messages. If not provided, the default message for the informative type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="ResultPaged{TData}"/> instance representing the informative response, including the status code and message(s) for the specified informative type.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default informative message associated with the specified <paramref name="informativeType"/> from the <see cref="HttpInformative"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// The method returns a <see cref="ResultPaged{TData}"/> instance containing the status code of the informative type, 
    /// with the data part set to <c>default</c> and page details set to <c>null</c> as the result represents an informative response.
    /// </remarks>
    public static ResultPaged<TData> Informative(InformativeType informativeType, IList<string>? message = null)
    {
        var informative = HttpInformative.GetInformative(informativeType);
        return new ResultPaged<TData>(
            statusCode: (int)informative.InformativeType, 
            count: 0, 
            page: null, 
            pageSize: null, 
            data: default, 
            nextPage: null, 
            previousPage: null,
            message ?? new List<string> { informative.Message! });
    }
    
    /// <summary>
    /// Creates a paginated redirect result with the specified redirect type and optional messages.
    /// </summary>
    /// <typeparam name="TData">
    /// The type of data that the result may contain. In this case, it will be <c>default</c> as the result represents a redirect response.
    /// </typeparam>
    /// <param name="redirectType">The type of redirect response to create a result for.</param>
    /// <param name="message">
    /// An optional list of custom redirect messages. If not provided, the default message for the redirect type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="ResultPaged{TData}"/> instance representing the redirect response, containing the status code and message(s) for the specified redirect type.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default redirect message associated with the specified <paramref name="redirectType"/> from the <see cref="HttpRedirect"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// The method returns a <see cref="ResultPaged{TData}"/> instance containing the status code of the redirect type and the corresponding message(s).
    /// </remarks>
    public static ResultPaged<TData> Redirect(RedirectType redirectType, IList<string>? message = null)
    {
        var redirect = HttpRedirect.GetRedirect(redirectType);
        return new ResultPaged<TData>(
            statusCode: (int)redirect.RedirectType, 
            count: 0, 
            page: null, 
            pageSize: null, 
            data: default, 
            nextPage: null, 
            previousPage: null,
            message ?? new List<string> { redirect.Message! });
    }
    
    /// <summary>
    /// Creates a paginated success result with the specified success type, pagination details, data, and optional messages.
    /// </summary>
    /// <typeparam name="TData">
    /// The type of data that the result contains. This allows the result to hold additional information relevant to the success.
    /// </typeparam>
    /// <param name="successType">The type of success response to create a result for.</param>
    /// <param name="count">The total count of items available in the dataset.</param>
    /// <param name="page">The current page number in the paginated result.</param>
    /// <param name="pageSize">The number of items per page in the paginated result.</param>
    /// <param name="data">The data associated with the success response.</param>
    /// <param name="nextPage">An optional URL or token for the next page of results, if available.</param>
    /// <param name="previousPage">An optional URL or token for the previous page of results, if available.</param>
    /// <param name="message">
    /// An optional list of custom success messages. If not provided, the default message for the success type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="ResultPaged{TData}"/> instance representing the success response, or <c>null</c> if no success messages are available for the specified success type.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default success messages associated with the specified <paramref name="successType"/> from the <see cref="HttpSuccess"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// The method returns the first <see cref="ResultPaged{TData}"/> instance created from the available messages for the success type, 
    /// containing the status code, the provided pagination details, the data, and the corresponding message(s). If no messages are found, it returns <c>null</c>.
    /// </remarks>
    public static ResultPaged<TData>? Success(
        SuccessType successType, 
        int count, 
        int page, 
        int pageSize, 
        TData data, 
        string? nextPage = null, 
        string? previousPage = null, 
        IList<string>? message = null)
    {
        var success = HttpSuccess.GetSuccess(successType);
        return success.Messages!.Select(successMessage => 
            new ResultPaged<TData>(
                (int)success.SuccessType, 
                count, 
                page, 
                pageSize, 
                data, 
                nextPage, 
                previousPage, 
                message ?? new List<string> { successMessage })).FirstOrDefault();
    }
}