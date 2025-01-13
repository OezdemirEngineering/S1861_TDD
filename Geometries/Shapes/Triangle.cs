using Geometries.Contracts;

namespace Geometries.Shapes;

/// <summary>
/// Represents a triangle geometry defined by its base and height.
/// </summary>
/// <param name="baseLength">The length of the base of the triangle.</param>
/// <param name="height">The height of the triangle.</param>
public class Triangle(double baseLength, double height) : IGeometry
{
    /// <summary>
    /// Gets the base length of the triangle.
    /// </summary>
    public double BaseLength { get; } = baseLength;

    /// <summary>
    /// Gets the height of the triangle.
    /// </summary>
    public double Height { get; } = height;

    /// <summary>
    /// Calculates the area of the triangle.
    /// </summary>
    /// <returns>The area of the triangle.</returns>
    public double GetArea()
    {
        return 0.5 * BaseLength * Height;
    }

    /// <summary>
    /// Calculates the perimeter of the triangle.
    /// Note: This requires additional information about the other two sides.
    /// </summary>
    /// <returns>The perimeter of the triangle.</returns>
    public double GetLength()
    {
        double sideA = Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(BaseLength / 2, 2));
        double sideB = sideA;
        return BaseLength + sideA + sideB;
    }
}
