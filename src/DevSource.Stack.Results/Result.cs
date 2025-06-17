using System.Text.Json.Serialization;
using DevSource.Stack.Results.Abstractions;
using DevSource.Stack.Results.StatusCodeTypes;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DevSource.Stack.Results;

public class Result : ResultBase
{
    public Result(int? statusCode, IList<string>? message = null)
    {
        StatusCode = statusCode;
        Messages = message;
    }
    
    /// <summary>
    /// Creates a failure result based on the specified error type and optional error messages.
    /// </summary>
    /// <param name="errorType">The type of error to create a failure result for.</param>
    /// <param name="message">
    /// An optional list of custom error messages. If not provided, the default error messages for the error type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="Result"/> instance representing the failure.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default error messages associated with the specified <paramref name="errorType"/> from the <see cref="HttpError"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// If no custom message is provided and no default message is configured for the <paramref name="errorType"/>, an <see cref="InvalidOperationException"/> is thrown.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if no custom message is provided and no default error message is configured for the specified <paramref name="errorType"/>.
    /// </exception>
    public static Result Failure(ErrorType errorType, IList<string>? message = null)
    {
        IErrorStatus errorDetails = new HttpErrorProvider().GetError(errorType);
        if (message != null)
        {
            return new Result((int)errorDetails.ErrorType, message);
        }

        if (errorDetails.Messages == null || !errorDetails.Messages.Any())
        {
            throw new InvalidOperationException($"No default error message is configured for ErrorType '{errorDetails.ErrorType}'.");
        }
        return new Result((int)errorDetails.ErrorType, errorDetails.Messages);
    }
    
    /// <summary>
    /// Creates an informative result based on the specified informative type and optional messages.
    /// </summary>
    /// <param name="informativeType">The type of informative response to create a result for.</param>
    /// <param name="message">
    /// An optional list of custom informative messages. If not provided, the default message for the informative type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="Result"/> instance representing the informative response, containing the status code and message(s) for the specified informative type.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default informative message associated with the specified <paramref name="informativeType"/> from the <see cref="HttpInformative"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// The method returns a <see cref="Result"/> instance containing the status code of the informative type and the corresponding message(s).
    /// </remarks>
    public static Result Informative(InformativeType informativeType, IList<string>? message = null)
    {
        IInformativeStatus informativeDetails = new HttpInformativeProvider().GetInformative(informativeType);
        return new Result((int)informativeDetails.InformativeType, message ?? informativeDetails.Messages);
    }
    
    /// <summary>
    /// Creates a redirect result based on the specified redirect type and optional messages.
    /// </summary>
    /// <param name="redirectType">The type of redirect response to create a result for.</param>
    /// <param name="message">
    /// An optional list of custom redirect messages. If not provided, the default message for the redirect type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="Result"/> instance representing the redirect response, containing the status code and message(s) for the specified redirect type.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default redirect message associated with the specified <paramref name="redirectType"/> from the <see cref="HttpRedirect"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// The method returns a <see cref="Result"/> instance containing the status code of the redirect type and the corresponding message(s).
    /// </remarks>
    public static Result Redirect(RedirectType redirectType, IList<string>? message = null)
    {
        IRedirectStatus redirectDetails = new HttpRedirectProvider().GetRedirect(redirectType);
        return new Result((int)redirectDetails.RedirectType, message ?? redirectDetails.Messages);
    }
    
    
    /// <summary>
    /// Creates a success result based on the specified success type and optional messages.
    /// </summary>
    /// <param name="successType">The type of success response to create a result for.</param>
    /// <param name="message">
    /// An optional list of custom success messages. If not provided, the default message for the success type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="Result"/> instance representing the success response.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default success messages associated with the specified <paramref name="successType"/> from the <see cref="HttpSuccess"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// If no custom message is provided and no default message is configured for the <paramref name="successType"/>, an <see cref="InvalidOperationException"/> is thrown.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if no custom message is provided and no default success message is configured for the specified <paramref name="successType"/>.
    /// </exception>
    public static Result Success(SuccessType successType, IList<string>? message = null)
    {
        ISuccessStatus successDetails = new HttpSuccessProvider().GetSuccess(successType);
        if (message != null)
        {
            return new Result((int)successDetails.SuccessType, message);
        }

        if (successDetails.Messages == null || !successDetails.Messages.Any())
        {
            throw new InvalidOperationException($"No default success message is configured for SuccessType '{successDetails.SuccessType}'.");
        }
        return new Result((int)successDetails.SuccessType, successDetails.Messages);
    }
}

public class Result<TData>: ResultBase
{
    [JsonPropertyName("data")] public TData? Data { get; init; }
    
    public Result(int? statusCode, TData? data, IList<string>? message = null)
    {
        StatusCode = statusCode;
        Data = data;
        Messages = message;
    }
    
    /// <summary>
    /// Creates a failure result with a specified error type and optional error messages.
    /// </summary>
    /// <typeparam name="TData">
    /// The type of data that the result may contain. In this case, it will be <c>default</c> as the result represents a failure.
    /// </typeparam>
    /// <param name="errorType">The type of error to create a failure result for.</param>
    /// <param name="message">
    /// An optional list of custom error messages. If not provided, the default error messages for the error type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="Result{TData}"/> instance representing the failure.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default error messages associated with the specified <paramref name="errorType"/> from the <see cref="HttpError"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// If no custom message is provided and no default message is configured for the <paramref name="errorType"/>, an <see cref="InvalidOperationException"/> is thrown.
    /// The data will be set to <c>default</c> for the type <typeparamref name="TData"/>.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if no custom message is provided and no default error message is configured for the specified <paramref name="errorType"/>.
    /// </exception>
    public static Result<TData> Failure(ErrorType errorType, IList<string>? message = null)
    {
        IErrorStatus errorDetails = new HttpErrorProvider().GetError(errorType);
        if (message != null)
        {
            return new Result<TData>((int)errorDetails.ErrorType, default, message);
        }

        if (errorDetails.Messages == null || !errorDetails.Messages.Any())
        {
            throw new InvalidOperationException($"No default error message is configured for ErrorType '{errorDetails.ErrorType}'.");
        }
        return new Result<TData>((int)errorDetails.ErrorType, default, errorDetails.Messages);
    }
    
    /// <summary>
    /// Creates an informative result with the specified informative type and optional messages.
    /// </summary>
    /// <typeparam name="TData">
    /// The type of data that the result may contain. In this case, it will be <c>default</c> as the result represents an informative response.
    /// </typeparam>
    /// <param name="informativeType">The type of informative response to create a result for.</param>
    /// <param name="message">
    /// An optional list of custom informative messages. If not provided, the default message for the informative type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="Result{TData}"/> instance representing the informative response, containing the status code and message(s) for the specified informative type.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default informative message associated with the specified <paramref name="informativeType"/> from the <see cref="HttpInformative"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// The method returns a <see cref="Result{TData}"/> instance containing the status code of the informative type and the corresponding message(s).
    /// </remarks>
    public static Result<TData> Informative(InformativeType informativeType, IList<string>? message = null)
    {
        IInformativeStatus informativeDetails = new HttpInformativeProvider().GetInformative(informativeType);
        return new Result<TData>((int)informativeDetails.InformativeType, default, message ?? informativeDetails.Messages);
    }
    
    /// <summary>
    /// Creates a redirect result with the specified redirect type and optional messages.
    /// </summary>
    /// <typeparam name="TData">
    /// The type of data that the result may contain. In this case, it will be <c>default</c> as the result represents a redirect response.
    /// </typeparam>
    /// <param name="redirectType">The type of redirect response to create a result for.</param>
    /// <param name="message">
    /// An optional list of custom redirect messages. If not provided, the default message for the redirect type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="Result{TData}"/> instance representing the redirect response, containing the status code and message(s) for the specified redirect type.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default redirect message associated with the specified <paramref name="redirectType"/> from the <see cref="HttpRedirect"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// The method returns a <see cref="Result{TData}"/> instance containing the status code of the redirect type and the corresponding message(s).
    /// </remarks>
    public static Result<TData> Redirect(RedirectType redirectType, IList<string>? message = null)
    {
        IRedirectStatus redirectDetails = new HttpRedirectProvider().GetRedirect(redirectType);
        return new Result<TData>((int)redirectDetails.RedirectType, default, message ?? redirectDetails.Messages);
    }
    
    /// <summary>
    /// Creates a success result with the specified success type, data, and optional messages.
    /// </summary>
    /// <typeparam name="TData">
    /// The type of data that the result contains. This allows the result to hold additional information relevant to the success.
    /// </typeparam>
    /// <param name="successType">The type of success response to create a result for.</param>
    /// <param name="data">
    /// The data associated with the success response. This can be any information relevant to the success context.
    /// </param>
    /// <param name="message">
    /// An optional list of custom success messages. If not provided, the default message for the success type will be used.
    /// </param>
    /// <returns>
    /// A <see cref="Result{TData}"/> instance representing the success response.
    /// </returns>
    /// <remarks>
    /// This method retrieves the default success messages associated with the specified <paramref name="successType"/> from the <see cref="HttpSuccess"/> class. 
    /// If custom messages are provided through the <paramref name="message"/> parameter, they will be used instead. 
    /// If no custom message is provided and no default message is configured for the <paramref name="successType"/>, an <see cref="InvalidOperationException"/> is thrown.
    /// The method returns a <see cref="Result{TData}"/> instance containing the status code, the provided data, and the corresponding message(s).
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if no custom message is provided and no default success message is configured for the specified <paramref name="successType"/>.
    /// </exception>
    public static Result<TData> Success(SuccessType successType, TData? data, IList<string>? message = null)
    {
        ISuccessStatus successDetails = new HttpSuccessProvider().GetSuccess(successType);
        if (message != null)
        {
            return new Result<TData>((int)successDetails.SuccessType, data, message);
        }

        if (successDetails.Messages == null || !successDetails.Messages.Any())
        {
            throw new InvalidOperationException($"No default success message is configured for SuccessType '{successDetails.SuccessType}'.");
        }
        return new Result<TData>((int)successDetails.SuccessType, data, successDetails.Messages);
    }
}