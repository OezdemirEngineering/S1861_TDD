using Geometries.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometries.Tests;

public class CircleTests
{


    [Theory]
    [InlineData(10, 10 * 10 * Math.PI)]
    [InlineData(20, 30 * 30 * Math.PI)]
    [InlineData(30, 30 * 30 * Math.PI)]
    public void GetArea_Radius_ExpectedCircumference(int radius, double expectedCircumference)
    {
        // Arrange
        var circle = new Circle(radius);

        // Act
        var circumference = circle.GetArea();

        // Assert
        Assert.Equal(expectedCircumference, circumference, 2);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(30)]
    public void GetCircumference_Radius_ExpectedCircumference(int radius)
    {
        // Arrange
        var circle = new Circle(radius);
        var expectedCircumference = 2 * Math.PI * radius;

        // Act
        var circumference = circle.GetLength();

        // Assert
        Assert.Equal(expectedCircumference, circumference, 2);
    }

}
