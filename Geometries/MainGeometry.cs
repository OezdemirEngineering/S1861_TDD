using Geometries.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Geometries;

/// <summary>
/// Represents a composite geometry containing multiple geometries,
/// allowing calculation of total area and total length.
/// </summary>
/// <param name="Shapes">The initial list of geometries contained in this composite geometry.</param>
public class MainGeometry(List<IGeometry> shapes) : IGeometry
{
    /// <summary>
    /// Gets the list of geometries contained in this composite geometry.
    /// </summary>
    public List<IGeometry> Shapes 
        => shapes;

    /// <summary>
    /// Adds a list of new geometries to the composite geometry.
    /// </summary>
    /// <param name="newGeometries">The list of geometries to add.</param>
    public void AddGeometries(IEnumerable<IGeometry> newGeometries)
        => Shapes.AddRange(newGeometries);

    /// <summary>
    /// Calculates the total area of all geometries in the composite geometry.
    /// </summary>
    /// <returns>The total area of all geometries.</returns>
    public double GetArea()
        => Shapes.Sum(geometry => geometry.GetArea());

    /// <summary>
    /// Calculates the total length (perimeter) of all geometries in the composite geometry.
    /// </summary>
    /// <returns>The total length of all geometries.</returns>
    public double GetLength()
        => Shapes.Sum(geometry => geometry.GetLength());
}
