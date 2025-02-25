using Geometries.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometries.Tests;

public class RectangleTests
{
    [Fact]
    public void GetLength_WidthHeight_ExpectedLength()
    {
        // Arrange
        var width = 10; 
        var height = 20;
        var rectangle = new Rectangle(width, height);
        var expectedLength = 60;

        // Act
        var length = rectangle.GetLength();


        // Assert
        Assert.Equal(expectedLength, length);
    }

    [Theory]
    [InlineData(10, 20, 200)]
    [InlineData(20, 30, 600)]
    [InlineData(30, 40, 1200)]
    public void GetArea_WidthsHeights_ExpectedArea(int width, int height, int expectedArea)
    {
        // Arrange
        var rectangle = new Rectangle(width, height);

        // Act
        var area = rectangle.GetArea();

        // Assert
        Assert.Equal(expectedArea, area);
    }

    [Theory]
    [InlineData(10, 20, 60)]
    [InlineData(20, 30, 100)]
    [InlineData(30, 40, 140)]
    public void GetLength_WidthsHeights_ExpectedLength(int width, int height, int expectedLength)
    {
        // Arrange
        var rectangle = new Rectangle(width, height);

        // Act
        var length = rectangle.GetLength();

        // Assert
        Assert.Equal(expectedLength, length);
    }


    [Fact]
    public void GetArea_WidthHeight_ExpectedArea()
    {
        // Arrange
        var width = 10;
        var height = 20;
        var rectangle = new Rectangle(width, height);

        // Act
        var area = rectangle.GetArea();

        // Assert
        Assert.Equal(200, area);
    }
}
