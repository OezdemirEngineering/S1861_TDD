using Geometries.Contracts;

namespace Geometries.Shapes;

/// <summary>
/// Represents a circle geometry with a specified radius.
/// </summary>
/// <param name="radius">The radius of the circle.</param>
public class Circle(double radius) : IGeometry
{
    /// <summary>
    /// Gets the radius of the circle.
    /// </summary>
    public double Radius { get; } = radius;

    /// <summary>
    /// Calculates the area of the circle.
    /// </summary>
    /// <returns>The area of the circle.</returns>
    public double GetArea()
        => Math.PI * Radius * Radius;

    /// <summary>
    /// Calculates the circumference (perimeter) of the circle.
    /// </summary>
    /// <returns>The circumference of the circle.</returns>
    public double GetLength()
        => 2 * Math.PI * Radius;
}
