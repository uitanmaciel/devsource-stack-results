using DevSource.Stack.Results.StatusCodeTypes;

namespace DevSource.Stack.Results.Tests;

[TestClass]
public class HttpInformativeTests
{
    [TestMethod]
    public void Informative_Continue_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 100;
        
        // Act
        // Execute the method to be tested
        var result = Result.Informative(InformativeType.Continue);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Informative_SwitchingProtocols_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 101;
        
        // Act
        // Execute the method to be tested
        var result = Result.Informative(InformativeType.SwitchingProtocols);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Informative_Processing_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 102;
        
        // Act
        // Execute the method to be tested
        var result = Result.Informative(InformativeType.Processing);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Informative_EarlyHints_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const bool isSuccessExpected = false;
        const int statusCodeExpected = 103;
        
        // Act
        // Execute the method to be tested
        var result = Result.Informative(InformativeType.EarlyHints);
        
        // Assert
        // Check if the result is as expected
        Assert.AreEqual(isSuccessExpected, result.IsSuccess);
        Assert.AreEqual(statusCodeExpected, result.StatusCode);
        Assert.IsTrue(result.Messages!.Any());
    }
    
    [TestMethod]
    public void Informative_InvalidInformativeType_Test()
    {
        // Arrange
        // Initialize the variables expected to be used in the test
        const InformativeType informativeType = (InformativeType)999;
        
        // Act
        // Execute the method to be tested
        // Assert
        // Check if the result is as expected
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Result.Informative(informativeType));
    }
}