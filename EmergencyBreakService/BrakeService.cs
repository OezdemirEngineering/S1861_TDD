using EmergencyBrakeService.Utils;
using UnitsNet;

namespace EmergencyBrakeService;

/// <summary>
/// Represents a brake service for handling emergency braking scenarios.
/// </summary>
/// <param name="minimalDistance">The minimal safe distance to avoid an emergency brake.</param>
/// <param name="currentSpeed">The current speed of the vehicle.</param>
/// <param name="frictionCoefficient">The friction coefficient of the road surface.</param>
public class BrakeService(Length minimalDistance, Speed currentSpeed, double frictionCoefficient)
{
    private Speed _currentSpeed = currentSpeed;
    private double _frictionCoefficient = frictionCoefficient;

    /// <summary>
    /// Gets the minimal safe distance to avoid an emergency brake.
    /// </summary>
    public Length MinimalDistance
        => minimalDistance;

    /// <summary>
    /// Gets or sets the current speed of the vehicle.
    /// </summary>
    public Speed CurrentSpeed
        => _currentSpeed;

    /// <summary>
    /// Gets or sets the friction coefficient of the road surface.
    /// </summary>
    public double FrictionCoefficient
        => _frictionCoefficient;

    /// <summary>
    /// Updates the current speed of the vehicle.
    /// </summary>
    /// <param name="newSpeed">The new speed to update to.</param>
    public void UpdateSpeed(Speed newSpeed)
    {
        if (newSpeed.MetersPerSecond < 0)
            throw new ArgumentOutOfRangeException(nameof(newSpeed), "Speed cannot be negative.");
        _currentSpeed = newSpeed;
    }

    /// <summary>
    /// Updates the friction coefficient of the road surface.
    /// </summary>
    /// <param name="newFrictionCoefficient">The new friction coefficient to update to.</param>
    public void UpdateFrictionCoefficient(double newFrictionCoefficient)
    {
        if (newFrictionCoefficient <= 0)
            throw new ArgumentOutOfRangeException(nameof(newFrictionCoefficient), "Friction coefficient must be greater than zero.");
        _frictionCoefficient = newFrictionCoefficient;
    }

    /// <summary>
    /// Determines whether an emergency brake is needed based on the current speed, minimal distance, and the distance to an obstacle.
    /// </summary>
    /// <param name="distanceToObstacle">The distance to the obstacle ahead.</param>
    /// <returns>
    /// <c>true</c> if an emergency brake is needed; otherwise, <c>false</c>.
    /// </returns>
    public bool IsEmergencyBreakNeeded(Length distanceToObstacle)
        => (CalculateBrakingDistance() + MinimalDistance) > distanceToObstacle;

    /// <summary>
    /// Calculates the braking distance based on the current speed and the friction coefficient.
    /// </summary>
    /// <returns>The calculated braking distance.</returns>
    public Length CalculateBrakingDistance()
    {
        var brakingDistance = BrakeDistanceHelper.CalculateBrakeDistance(CurrentSpeed.MetersPerSecond, FrictionCoefficient);
        return Length.FromMeters(brakingDistance);
    }
}
