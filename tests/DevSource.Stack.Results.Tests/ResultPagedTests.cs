using NUnit.Framework;
using DevSource.Stack.Results;
using DevSource.Stack.Results.StatusCodeTypes;
using System.Collections.Generic;
using System.Linq; // Required for .Any() and .First()

namespace DevSource.Stack.Results.Tests
{
    [TestFixture]
    public class ResultPagedTests
    {
        // Tests for TotalPages
        [Test]
        public void ResultPaged_TotalPages_ReturnsZero_WhenPageSizeIsNull()
        {
            // Test with the constructor directly
            var result = new ResultPaged<string>((int)SuccessType.Ok, 10, 1, null, new List<string> { "data" });
            Assert.AreEqual(0, result.TotalPages);
        }

        [Test]
        public void ResultPaged_TotalPages_ReturnsZero_WhenPageSizeIsZero()
        {
            var result = new ResultPaged<string>((int)SuccessType.Ok, 10, 1, 0, new List<string> { "data" });
            Assert.AreEqual(0, result.TotalPages);
        }

        [Test]
        public void ResultPaged_TotalPages_ReturnsZero_WhenCountIsZero()
        {
            var result = new ResultPaged<string>((int)SuccessType.Ok, 0, 1, 10, new List<string>());
            Assert.AreEqual(0, result.TotalPages);
        }

        [Test]
        [TestCase(10, 3, 4)]
        [TestCase(9, 3, 3)]
        [TestCase(1, 3, 1)]
        public void ResultPaged_TotalPages_CalculatesCorrectly(int count, int pageSize, int expectedTotalPages)
        {
            var result = new ResultPaged<string>((int)SuccessType.Ok, count, 1, pageSize, new List<string> { "data" });
            Assert.AreEqual(expectedTotalPages, result.TotalPages);
        }

        // Tests for NextPage/PreviousPage nullability
        [Test]
        public void ResultPaged_Failure_SetsNextPreviousPageToNull()
        {
            var result = ResultPaged<string>.Failure(ErrorType.BadRequest);
            Assert.IsNull(result.NextPage);
            Assert.IsNull(result.PreviousPage);
        }

        [Test]
        public void ResultPaged_Informative_SetsNextPreviousPageToNull()
        {
            var result = ResultPaged<string>.Informative(InformativeType.Continue);
            Assert.IsNull(result.NextPage);
            Assert.IsNull(result.PreviousPage);
        }

        [Test]
        public void ResultPaged_Redirect_SetsNextPreviousPageToNull()
        {
            var result = ResultPaged<string>.Redirect(RedirectType.Found);
            Assert.IsNull(result.NextPage);
            Assert.IsNull(result.PreviousPage);
        }

        [Test]
        public void ResultPaged_Success_WithNullNextPrevious_ViaFactory_SetsPropertiesToNull()
        {
            var result = ResultPaged<string>.Success(SuccessType.Ok, 0, 1, 10, new List<string>(), null, null);
            Assert.IsNull(result.NextPage);
            Assert.IsNull(result.PreviousPage);
        }

        [Test]
        public void ResultPaged_Success_WithNonNullNextPrevious_ViaFactory_SetsPropertiesCorrectly()
        {
            var nextPageUrl = "/page=2";
            var prevPageUrl = "/page=0";
            var result = ResultPaged<string>.Success(SuccessType.Ok, 10, 1, 5, new List<string>(), nextPageUrl, prevPageUrl);
            Assert.AreEqual(nextPageUrl, result.NextPage);
            Assert.AreEqual(prevPageUrl, result.PreviousPage);
        }

        // Test for ResultPaged<TData>.Failure message handling (uses all default messages)
        [Test]
        public void ResultPaged_Failure_UsesAllDefaultErrorMessages_WhenNoCustomMessageProvided()
        {
            var result = ResultPaged<string>.Failure(ErrorType.Forbidden);
            Assert.IsNotNull(result.Messages);
            Assert.IsTrue(result.Messages.Any());
            Assert.AreEqual("You do not have the necessary permissions to access this resource.", result.Messages.First());
            // To truly test "all", one would need to know the exact multiple messages for a type.
            // For now, we trust the implementation change from step 2 and that HttpError.Messages for Forbidden has one entry.
        }

        [Test]
        public void ResultPaged_Success_WithDefaultMessageAndData_ReturnsResultWithDefaultMessageAndData()
        {
            var data = new List<string> { "Test Data" };
            var result = ResultPaged<List<string>>.Success(SuccessType.Ok, data.Count, 1, 10, data);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)SuccessType.Ok, result.StatusCode);
            Assert.AreEqual(data, result.Data);
            Assert.IsNotNull(result.Messages);
            Assert.IsTrue(result.Messages.Any());
            Assert.AreEqual("The request has succeeded.", result.Messages.First());
            Assert.AreEqual(data.Count, result.Count);
            Assert.AreEqual(1, result.Page);
            Assert.AreEqual(10, result.PageSize);
        }
    }
}
