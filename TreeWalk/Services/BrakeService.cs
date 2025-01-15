using EmergencyBrakeService.Utils;
using ServiceHell.Contracts;
using UnitsNet;

namespace EmergencyBrakeService;

/// <summary>
/// Represents a brake service for handling emergency braking scenarios.
/// </summary>
/// <param name="minimalDistance">The minimal safe distance to avoid an emergency brake.</param>
/// <param name="currentSpeed">The current speed of the vehicle.</param>
/// <param name="frictionCoefficient">The friction coefficient of the road surface.</param>
public class BrakeService(
    Length minimalDistance, 
    Speed currentSpeed,
    IDistanceSensorService distanceSensorService,
    IBrakeDistanceCalculatorService brakeDistanceCalculatorService, 
    ILoggerService logger)
{
    public IBrakeDistanceCalculatorService BrakeDistanceCalculatorService => brakeDistanceCalculatorService;
    public IDistanceSensorService DistanceSensorService => distanceSensorService;
    public ILoggerService Logger => logger;

    private Speed _currentSpeed = currentSpeed;


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
    /// Determines whether an emergency brake is needed based on the current speed, minimal distance, and the distance to an obstacle.
    /// </summary>
    /// <param name="distanceToObstacle">The distance to the obstacle ahead.</param>
    /// <returns>
    /// <c>true</c> if an emergency brake is needed; otherwise, <c>false</c>.
    /// </returns>
    public bool IsEmergencyBreakNeeded()
        => (Length.FromMeters(BrakeDistanceCalculatorService.CalculateBrakeDistance(CurrentSpeed.KilometersPerHour)) + MinimalDistance) > DistanceSensorService.GetLength();

}
