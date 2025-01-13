using Calculator.Utils;

namespace Calculator.Nunit.Tests;

public class CalculatorHelperTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TearDown] 
    public void TearDown() 
    { 
    }

    [Test]
    public void Add_TwoIntegers_ExpectedSum()
    {
        // Arrange
        var operand1 = 5;
        var operand2 = 3;
        var expected = 8;

        // Act
        var actual = CalculatorHelper.Add(operand1, operand2);

        // Assert
        Assert.That(expected, Is.EqualTo( actual));
    }

    [Test]
    public void Subtract_TwoIntegers_ExpectedDifference()
    {
        // Arrange
        var operand1 = 5;
        var operand2 = 3;
        var expected = 2;
        // Act
        var actual = CalculatorHelper.Subtract(operand1, operand2);
        // Assert
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Multiply_TwoIntegers_ExpectedProduct()
    {
        // Arrange
        var operand1 = 5;
        var operand2 = 3;
        var expected = 15;

        // Act
        var actual = CalculatorHelper.Multiply(operand1, operand2);

        // Assert
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Divide_TwoIntegers_ExpectedQuotient()
    {
        // Arrange
        var operand1 = 6;
        var operand2 = 3;
        var expected = 2.0;

        // Act
        var actual = CalculatorHelper.Divide(operand1, operand2);


        // Assert
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        var operand1 = 6;
        var operand2 = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => CalculatorHelper.Divide(operand1, operand2));
    }

    [TestCase(5, 25)]
    [TestCase(3, 9)]
    public void Square_Integer_ExpectedSquare(int a, int expected)
    {
        // Act
        var actual = CalculatorHelper.Square(a);

        // Assert
        Assert.That(expected, Is.EqualTo(actual));
    }

}
