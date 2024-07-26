using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results.Tests;

[TestClass]
public class HttpSuccessTests
{
    [TestMethod]
    public void Success_Ok_Test()
    {
        // Arrange
        const bool isSuccessExpected = true;
        const int statusCodeExpected = 200;
        
        // Act
        var result = Result.Success(SuccessType.Ok);
        
        // Assert
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Success_Created_Test()
    {
        // Arrange
        const bool isSuccessExpected = true;
        const int statusCodeExpected = 201;
        
        // Act
        var result = Result.Success(SuccessType.Created);
        
        // Assert
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Success_Accepted_Test()
    {
        // Arrange
        const bool isSuccessExpected = true;
        const int statusCodeExpected = 202;
        
        // Act
        var result = Result.Success(SuccessType.Accepted);
        
        // Assert
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Success_NonAuthoritativeInformation_Test()
    {
        // Arrange
        const bool isSuccessExpected = true;
        const int statusCodeExpected = 203;
        
        // Act
        var result = Result.Success(SuccessType.NonAuthoritativeInformation);
        
        // Assert
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Success_NoContent_Test()
    {
        // Arrange
        const bool isSuccessExpected = true;
        const int statusCodeExpected = 204;
        
        // Act
        var result = Result.Success(SuccessType.NoContent);
        
        // Assert
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Success_ResetContent_Test()
    {
        // Arrange
        const bool isSuccessExpected = true;
        const int statusCodeExpected = 205;
        
        // Act
        var result = Result.Success(SuccessType.ResetContent);
        
        // Assert
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Success_PartialContent_Test()
    {
        // Arrange
        const bool isSuccessExpected = true;
        const int statusCodeExpected = 206;
        
        // Act
        var result = Result.Success(SuccessType.PartialContent);
        
        // Assert
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Success_MultiStatus_Test()
    {
        // Arrange
        const bool isSuccessExpected = true;
        const int statusCodeExpected = 207;
        
        // Act
        var result = Result.Success(SuccessType.MultiStatus);
        
        // Assert
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Success_AlreadyReported_Test()
    {
        // Arrange
        const bool isSuccessExpected = true;
        const int statusCodeExpected = 208;
        
        // Act
        var result = Result.Success(SuccessType.AlreadyReported);
        
        // Assert
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Success_IMUsed_Test()
    {
        // Arrange
        const bool isSuccessExpected = true;
        const int statusCodeExpected = 226;
        
        // Act
        var result = Result.Success(SuccessType.IMUsed);
        
        // Assert
        Assert.AreEqual(isSuccessExpected, result!.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
}