using Geometries.Contracts;

namespace Geometries.Shapes;

/// <summary>
/// Represents a rectangle geometry with specified width and height.
/// </summary>
/// <param name="width">The width of the rectangle.</param>
/// <param name="height">The height of the rectangle.</param>
public class Rectangle(double width, double height) : IGeometry
{
    /// <summary>
    /// Gets the width of the rectangle.
    /// </summary>
    public double Width 
        => width;

    /// <summary>
    /// Gets the height of the rectangle.
    /// </summary>
    public double Height
        => height;

    /// <summary>
    /// Calculates the area of the rectangle.
    /// </summary>
    /// <returns>The area of the rectangle.</returns>
    public double GetArea()
        => Width * Height;

    /// <summary>
    /// Calculates the perimeter (length) of the rectangle.
    /// </summary>
    /// <returns>The perimeter of the rectangle.</returns>
    public double GetLength()
        => 2 * (Width + Height);
}
