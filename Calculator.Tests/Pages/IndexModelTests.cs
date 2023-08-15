using Calculator.Domain.Interfaces;
using Calculator.Pages;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace Calculator.Tests.Pages;

public class IndexModelTests
{
    private ICalculatorService _calculator;
    private IndexModel _indexModel;
    private ILogger<IndexModel> _logger;

    [SetUp]
    public void Setup()
    {
        _logger = Mock.Of<ILogger<IndexModel>>();
        _calculator = Mock.Of<ICalculatorService>();
        _indexModel = new IndexModel(_logger, _calculator);
    }

    [Test]
    public void OnPost_Add_Success()
    {
        // Arrange
        const int left = 2;
        const string operation = "+";
        const int right = 3;
        const int expectedResult = 5;
        Mock.Get(_calculator).Setup(x => x.Add(left, right)).Returns(Result.Success(expectedResult));

        // Act
        _indexModel.OnPost(left, operation, right);

        // Assert
        _indexModel.Result.ShouldBe(expectedResult);
        _indexModel.Error.ShouldBeNull();
    }


    [Test]
    public void OnPost_Subtract_Success()
    {
        // Arrange
        const int left = 5;
        const string operation = "-";
        const int right = 3;
        const int expectedResult = 2;
        Mock.Get(_calculator).Setup(x => x.Subtract(left, right)).Returns(Result.Success(expectedResult));

        // Act
        _indexModel.OnPost(left, operation, right);

        // Assert
        _indexModel.Result.ShouldBe(expectedResult);
        _indexModel.Error.ShouldBeNull();
    }

    [Test]
    public void OnPost_Multiply_Success()
    {
        // Arrange
        const int left = 2;
        const string operation = "*";
        const int right = 3;
        const int expectedResult = 6;
        Mock.Get(_calculator).Setup(x => x.Multiply(left, right)).Returns(Result.Success(expectedResult));

        // Act
        _indexModel.OnPost(left, operation, right);

        // Assert
        _indexModel.Result.ShouldBe(expectedResult);
        _indexModel.Error.ShouldBeNull();
    }

    [Test]
    public void OnPost_Divide_Success()
    {
        // Arrange
        const int left = 6;
        const string operation = "/";
        const int right = 3;
        const int expectedResult = 2;
        Mock.Get(_calculator).Setup(x => x.Divide(left, right)).Returns(Result.Success(expectedResult));

        // Act
        _indexModel.OnPost(left, operation, right);

        // Assert
        _indexModel.Result.ShouldBe(expectedResult);
        _indexModel.Error.ShouldBeNull();
    }

    [Test]
    public void OnPost_Divide_Failure()
    {
        // Arrange
        const int left = 6;
        const string operation = "/";
        const int right = 0;
        const string expectedError = "Cannot divide by zero";
        Mock.Get(_calculator).Setup(x => x.Divide(left, right)).Returns(Result.Failure<int>(expectedError));

        // Act
        _indexModel.OnPost(left, operation, right);

        // Assert
        _indexModel.Result.ShouldBeNull();
        _indexModel.Error.ShouldBe(expectedError);
    }
}