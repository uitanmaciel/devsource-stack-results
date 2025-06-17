using NUnit.Framework;
using DevSource.Stack.Results;
using DevSource.Stack.Results.StatusCodeTypes;
using System.Collections.Generic;
using System.Linq; // Required for .Any() and .First()

namespace DevSource.Stack.Results.Tests
{
    [TestFixture]
    public class ResultTests
    {
        // Tests for Result.Failure
        [Test]
        public void Result_Failure_WithDefaultMessage_ReturnsResultWithDefaultMessage()
        {
            var result = Result.Failure(ErrorType.BadRequest);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)ErrorType.BadRequest, result.StatusCode);
            Assert.IsNotNull(result.Messages);
            Assert.IsTrue(result.Messages.Any());
            // Assuming HttpError.GetError(ErrorType.BadRequest).Messages contains known message(s)
            // This part depends on the actual default message for BadRequest
            Assert.AreEqual("Your request could not be understood due to malformed syntax.", result.Messages.First());
        }

        [Test]
        public void Result_Failure_WithCustomMessage_ReturnsResultWithCustomMessage()
        {
            var customMessages = new List<string> { "Custom error message" };
            var result = Result.Failure(ErrorType.BadRequest, customMessages);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)ErrorType.BadRequest, result.StatusCode);
            Assert.AreEqual(customMessages, result.Messages);
        }

        // Tests for Result.Success
        [Test]
        public void Result_Success_WithDefaultMessage_ReturnsResultWithDefaultMessage()
        {
            var result = Result.Success(SuccessType.Ok);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)SuccessType.Ok, result.StatusCode);
            Assert.IsNotNull(result.Messages);
            Assert.IsTrue(result.Messages.Any());
            Assert.AreEqual("The request has succeeded.", result.Messages.First());
        }

        [Test]
        public void Result_Success_WithCustomMessage_ReturnsResultWithCustomMessage()
        {
            var customMessages = new List<string> { "Custom success message" };
            var result = Result.Success(SuccessType.Ok, customMessages);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)SuccessType.Ok, result.StatusCode);
            Assert.AreEqual(customMessages, result.Messages);
        }

        // Tests for Result<TData>.Failure
        [Test]
        public void ResultTData_Failure_WithDefaultMessage_ReturnsResultWithDefaultMessageAndNullData()
        {
            var result = Result<string>.Failure(ErrorType.NotFound);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)ErrorType.NotFound, result.StatusCode);
            Assert.IsNull(result.Data);
            Assert.IsNotNull(result.Messages);
            Assert.IsTrue(result.Messages.Any());
            Assert.AreEqual("The requested resource could not be found.", result.Messages.First());
        }

        [Test]
        public void ResultTData_Failure_WithCustomMessage_ReturnsResultWithCustomMessageAndNullData()
        {
            var customMessages = new List<string> { "Custom not found" };
            var result = Result<string>.Failure(ErrorType.NotFound, customMessages);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)ErrorType.NotFound, result.StatusCode);
            Assert.IsNull(result.Data);
            Assert.AreEqual(customMessages, result.Messages);
        }

        // Tests for Result<TData>.Success
        [Test]
        public void ResultTData_Success_WithDefaultMessageAndData_ReturnsResultWithDefaultMessageAndData()
        {
            var data = "Test Data";
            var result = Result<string>.Success(SuccessType.Ok, data);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)SuccessType.Ok, result.StatusCode);
            Assert.AreEqual(data, result.Data);
            Assert.IsNotNull(result.Messages);
            Assert.IsTrue(result.Messages.Any());
            Assert.AreEqual("The request has succeeded.", result.Messages.First());
        }

        [Test]
        public void ResultTData_Success_WithCustomMessageAndData_ReturnsResultWithCustomMessageAndData()
        {
            var data = "Test Data";
            var customMessages = new List<string> { "Custom OK" };
            var result = Result<string>.Success(SuccessType.Ok, data, customMessages);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)SuccessType.Ok, result.StatusCode);
            Assert.AreEqual(data, result.Data);
            Assert.AreEqual(customMessages, result.Messages);
        }

        // Test for IsSuccess property
        [Test]
        public void Result_IsSuccess_TrueForSuccessCodes()
        {
            var result = Result.Success(SuccessType.Ok);
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void Result_IsSuccess_FalseForErrorCodes()
        {
            var result = Result.Failure(ErrorType.BadRequest);
            Assert.IsFalse(result.IsSuccess);
        }

        [Test]
        public void Result_IsSuccess_FalseForRedirectCodes()
        {
            var result = Result.Redirect(RedirectType.MovedPermanently);
            Assert.IsFalse(result.IsSuccess); // Assuming redirects are not "IsSuccess"
        }

        [Test]
        public void Result_IsSuccess_FalseForInformativeCodes()
        {
            var result = Result.Informative(InformativeType.Continue);
            Assert.IsFalse(result.IsSuccess); // Assuming informative are not "IsSuccess"
        }
    }
}
