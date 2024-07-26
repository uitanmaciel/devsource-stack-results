using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results.Tests;

[TestClass]
public class HttpErrorTests
{
    [TestMethod]
    public void Error_BadRequest_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 400;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.BadRequest);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_Unauthorized_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 401;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.Unauthorized);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_PaymentRequired_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 402;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.PaymentRequired);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_Forbidden_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 403;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.Forbidden);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_NotFound_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 404;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.NotFound);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_MethodNotAllowed_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 405;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.MethodNotAllowed);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_NotAcceptable_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 406;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.NotAcceptable);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_ProxyAuthenticationRequired_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 407;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.ProxyAuthenticationRequired);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_RequestTimeout_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 408;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.RequestTimeout);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_Conflict_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 409;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.Conflict);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_Gone_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 410;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.Gone);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_LengthRequired_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 411;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.LengthRequired);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_PreconditionFailed_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 412;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.PreconditionFailed);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_PayloadTooLarge_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 413;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.PayloadTooLarge);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_URITooLong_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 414;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.UriToLong);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_UnsupportedMediaType_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 415;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.UnsupportedMediaType);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_RangeNotSatisfiable_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 416;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.RangeNotSatisfiable);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_ExpectationFailed_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 417;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.ExpectationFailed);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_MisdirectedRequest_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 421;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.MisdirectedRequest);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_UnprocessableEntity_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 422;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.UnprocessableContent);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_Locked_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 423;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.Locked);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_FailedDependency_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 424;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.FailedDependency);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_TooEarly_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 425;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.TooEarly);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_UpgradeRequired_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 426;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.UpgradeRequired);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_PreconditionRequired_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 428;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.PreconditionRequired);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_TooManyRequests_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 429;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.TooManyRequests);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_RequestHeaderFieldsTooLarge_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 431;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.RequestHeaderFieldsTooLarge);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_UnavailableForLegalReasons_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 451;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.UnavailableForLegalReasons);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_InternalServerError_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 500;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.InternalServerError);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_NotImplemented_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 501;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.NotImplemented);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_BadGateway_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 502;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.BadGateway);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_ServiceUnavailable_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 503;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.ServiceUnavailable);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_GatewayTimeout_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 504;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.GatewayTimeout);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_HTTPVersionNotSupported_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 505;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.HttpVersionNotSupported);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_VariantAlsoNegotiates_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 506;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.VariantAlsoNegotiates);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_InsufficientStorage_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 507;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.InsufficientStorage);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_LoopDetected_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 508;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.LoopDetected);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_NotExtended_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 510;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.NotExtended);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Error_NetworkAuthenticationRequired_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 511;
        
        // Act
        // Execute the method to be tested
        var result = Result.Failure(ErrorType.NetworkAuthenticationRequired);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result!.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
}