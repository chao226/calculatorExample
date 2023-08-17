using Calculator.Domain.Interfaces;
using CSharpFunctionalExtensions;

namespace Calculator.Domain.Services
{
    /// <summary>
    /// Provides methods for performing arithmetic operations.
    /// </summary>
    public class CalculatorService : ICalculatorService
    {
        private const string DivideByZeroErrorMessage = "Cannot divide by zero.";

        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="a">The first integer to add.</param>
        /// <param name="b">The second integer to add.</param>
        /// <returns>A <see cref="Result{T}"/> object that encapsulates the result of the operation or an error message if an error occurs.</returns>
        public Result<int> Add(int a, int b)
        {
            try
            {
                checked
                {
                    int result = a + b;
                    return Result.Success(result);
                }
            }
            catch (System.OverflowException ex)
            {
                return Result.Failure<int>(ex.Message);
            }
        }

        /// <summary>
        /// Subtracts one integer from another and returns the result.
        /// </summary>
        /// <param name="a">The integer to subtract from.</param>
        /// <param name="b">The integer to subtract.</param>
        /// <returns>A <see cref="Result{T}"/> object that encapsulates the result of the operation or an error message if an error occurs.</returns>
        public Result<int> Subtract(int a, int b)
        {
            try
            {
                checked
                {
                    int result = a - b;
                    return Result.Success(result);
                }
            }
            catch (System.OverflowException ex)
            {
                return Result.Failure<int>(ex.Message);
            }
        }

        /// <summary>
        /// Divides one integer by another and returns the result.
        /// </summary>
        /// <param name="a">The integer to divide.</param>
        /// <param name="b">The integer to divide by.</param>
        /// <returns>A <see cref="Result{T}"/> object that encapsulates the result of the operation or an error message if an error occurs.</returns>
        /// <exception cref="System.DivideByZeroException">Thrown when the second argument is zero.</exception>
        public Result<int> Divide(int a, int b)
        {
            if (b == 0)
            {
                return Result.Failure<int>(DivideByZeroErrorMessage);
            }

            int result = a / b;
            return Result.Success(result);
        }

        /// <summary>
        /// Multiplies two integers and returns the result.
        /// </summary>
        /// <param name="a">The first integer to multiply.</param>
        /// <param name="b">The second integer to multiply.</param>
        /// <returns>A <see cref="Result{T}"/> object that encapsulates the result of the operation or an error message if an error occurs.</returns>
        public Result<int> Multiply(int a, int b)
        {
            try
            {
                checked
                {
                    int result = a * b;
                    return Result.Success(result);
                }
            }
            catch (System.OverflowException ex)
            {
                return Result.Failure<int>(ex.Message);
            }
        }
    }
}