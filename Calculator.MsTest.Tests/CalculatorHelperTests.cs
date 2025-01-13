using Calculator.Utils;
using Microsoft.Testing.Platform.Extensions.TestFramework;

namespace Calculator.MsTest.Tests;

[TestClass]
public sealed class CalculatorTests
{
    [TestInitialize]
    public void TestInitialize()
    {
        // Arrange
        // Initialize resources
    }

    [TestCleanup]
    public void TestCleanup()
    {
        // Clean up resources
    }

    [TestMethod]
    public void Add_TwoIntegers_ExpectedSum()
    {
        // Arrange
        var operand1 = 5;
        var operand2 = 3;
        var expected = 8;

        // Act
        var actual = CalculatorHelper.Add(operand1, operand2);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Subtract_TwoIntegers_ExpectedDifference()
    {
        // Arrange
        var operand1 = 5;
        var operand2 = 3;
        var expected = 2;

        // Act
        var actual = CalculatorHelper.Subtract(operand1, operand2);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Multiply_TwoIntegers_ExpectedProduct()
    {
        // Arrange
        var operand1 = 5;
        var operand2 = 3;
        var expected = 15;


        // Act
        var actual = CalculatorHelper.Multiply(operand1, operand2);

        // Assert
        Assert.AreEqual(expected, actual, "actual differs from expceted Value{0}", expected);
    }

    [TestMethod]
    public void Divide_TwoDoubles_ExpectedQuotient()
    {
        // Arrange
        var operand1 = 5.0;
        var operand2 = 3.0;
        var expected = 1.6666666666666667;

        // Act
        var actual = CalculatorHelper.Divide(operand1, operand2);

        // Assert
        Assert.AreEqual(expected, actual, 0.000000000000001);
    }

    [TestMethod]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        var operand1 = 5.0;
        var operand2 = 0.0;

        // Act & Assert
        Assert.ThrowsException<DivideByZeroException>(() => CalculatorHelper.Divide(operand1, operand2));
    }



}

