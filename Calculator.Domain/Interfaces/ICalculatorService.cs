using CSharpFunctionalExtensions;

namespace Calculator.Domain.Interfaces;

public interface ICalculatorService
{
    /// <summary>
    /// Adds two integers and returns the result.
    /// </summary>
    /// <param name="a">The first integer to add.</param>
    /// <param name="b">The second integer to add.</param>
    /// <returns>A <see cref="Result{T}"/> object that encapsulates the result of the operation or an error message if an error occurs.</returns>
    Result<int> Add(int a, int b);

    /// <summary>
    /// Subtracts one integer from another and returns the result.
    /// </summary>
    /// <param name="a">The integer to subtract from.</param>
    /// <param name="b">The integer to subtract.</param>
    /// <returns>A <see cref="Result{T}"/> object that encapsulates the result of the operation or an error message if an error occurs.</returns>
    Result<int> Subtract(int a, int b);

    /// <summary>
    /// Divides one integer by another and returns the result.
    /// </summary>
    /// <param name="a">The integer to divide.</param>
    /// <param name="b">The integer to divide by.</param>
    /// <returns>A <see cref="Result{T}"/> object that encapsulates the result of the operation or an error message if an error occurs.</returns>
    /// <exception cref="System.DivideByZeroException">Thrown when the second argument is zero.</exception>
    Result<int> Divide(int a, int b);

    /// <summary>
    /// Multiplies two integers and returns the result.
    /// </summary>
    /// <param name="a">The first integer to multiply.</param>
    /// <param name="b">The second integer to multiply.</param>
    /// <returns>A <see cref="Result{T}"/> object that encapsulates the result of the operation or an error message if an error occurs.</returns>
    Result<int> Multiply(int a, int b);
}