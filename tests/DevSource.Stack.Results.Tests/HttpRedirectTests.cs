using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results.Tests;

[TestClass]
public class HttpRedirectTests
{
    [TestMethod]
    public void Redirect_MultipleChoices_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 300;
        
        // Act
        // Execute the method to be tested
        var result = Result.Redirect(RedirectType.MultipleChoices);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Redirect_MovedPermanently_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 301;
        
        // Act
        // Execute the method to be tested
        var result = Result.Redirect(RedirectType.MovedPermanently);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Redirect_Found_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 302;
        
        // Act
        // Execute the method to be tested
        var result = Result.Redirect(RedirectType.Found);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Redirect_SeeOther_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 303;
        
        // Act
        // Execute the method to be tested
        var result = Result.Redirect(RedirectType.SeeOther);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Redirect_NotModified_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 304;
        
        // Act
        // Execute the method to be tested
        var result = Result.Redirect(RedirectType.NotModified);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Redirect_TemporaryRedirect_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 307;
        
        // Act
        // Execute the method to be tested
        var result = Result.Redirect(RedirectType.TemporaryRedirect);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Redirect_PermanentRedirect_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 308;
        
        // Act
        // Execute the method to be tested
        var result = Result.Redirect(RedirectType.PermanentRedirect);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Redirect_Unsupported_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const RedirectType redirectType = (RedirectType) 999;
        
        // Act
        // Execute the method to be tested
        // Assert
        // Check if the result is as expected
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Result.Redirect(redirectType));
    }
}