using Calculator.Domain.Services;
using Shouldly;

namespace Calculator.Domain.Tests.Services
{
    public class CalculatorTests
    {
        private CalculatorService _calculatorService;

        [SetUp]
        public void Setup()
        {
            _calculatorService = new Domain.Services.CalculatorService();
        }

        [Test]
        public void Add_ShouldReturnCorrectResult()
        {
            // Arrange
            int a = 2;
            int b = 3;

            // Act
            var result = _calculatorService.Add(a, b);

            // Assert
            result.IsSuccess.ShouldBeTrue();
            result.ShouldBe(5);
        }

        [Test]
        public void Subtract_ShouldReturnCorrectResult()
        {
            // Arrange
            int a = 5;
            int b = 3;

            // Act
            var result = _calculatorService.Subtract(a, b);

            // Assert
            result.IsSuccess.ShouldBeTrue();
            result.ShouldBe(2);
        }

        [Test]
        public void Devide_ShouldReturnCorrectResult()
        {
            // Arrange
            int a = 6;
            int b = 3;

            // Act
            var result = _calculatorService.Divide(a, b);

            // Assert
            result.IsSuccess.ShouldBeTrue();
            result.ShouldBe(2);
        }

        [Test]
        public void Devide_ShouldThrowDivideByZeroException()
        {
            // Arrange
            int a = 6;
            int b = 0;

            // Act
            var result = _calculatorService.Divide(a, b);

            //Assert
            result.IsFailure.ShouldBeTrue();
            result.Error.ShouldBe("Cannot divide by zero.");
        }
    }
}