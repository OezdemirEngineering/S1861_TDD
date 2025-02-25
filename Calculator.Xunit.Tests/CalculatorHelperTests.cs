using Calculator.Utils;

namespace Calculator.Xunit.Tests;

public class CalculatorHelperTests 
{

    [Fact]
    public void Add_TwoIntegers_ExpectedSum()
    {
        // Arrange
        var operand1 = 5;
        var operand2 = 3;
        var expected = 8;

        // Act
        var actual = CalculatorHelper.Add(operand1, operand2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Subtract_TwoIntegers_ExpectedDifference()
    {
        // Arrange
        var operand1 = 5;
        var operand2 = 3;
        var expected = 2;

        // Act
        var actual = CalculatorHelper.Subtract(operand1, operand2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Multiply_TwoIntegers_ExpectedProduct()
    {
        // Arrange
        var operand1 = 5;
        var operand2 = 3;
        var expected = 15;

        // Act
        var actual = CalculatorHelper.Multiply(operand1, operand2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Divide_TwoIntegers_ExpectedQuotient()
    {
        // Arrange
        var operand1 = 6;
        var operand2 = 3;
        var expected = 2;

        // Act
        var actual = CalculatorHelper.Divide(operand1, operand2);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        var operand1 = 6;
        var operand2 = 0;

        // Act 
        var catchedException = Record.Exception(() => CalculatorHelper.Divide(operand1, operand2));

        //Assert
        Assert.IsType<Exception> (catchedException);
    }
}
