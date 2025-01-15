using ServiceHell.Contracts;
using UnitsNet;

namespace EmergencyBrakeService.Services;

/// <summary>
/// Represents a brake service for handling emergency braking scenarios.
/// </summary>
/// <param name="minimalDistance">The minimal safe distance to avoid an emergency brake.</param>
/// <param name="currentSpeed">The current speed of the vehicle.</param>
/// <param name="frictionCoefficient">The friction coefficient of the road surface.</param>
public class BrakeService(
    IDistanceSensorService distanceSensorService,
    IBrakeDistanceCalculatorService brakeDistanceCalculatorService, 
    ILoggerService logger)
{
    public IBrakeDistanceCalculatorService BrakeDistanceCalculatorService => brakeDistanceCalculatorService;
    public IDistanceSensorService DistanceSensorService => distanceSensorService;
    public ILoggerService Logger => logger;

    /// <summary>
    /// Determines whether an emergency brake is needed based on the current speed, minimal distance, and the distance to an obstacle.
    /// </summary>
    /// <param name="distanceToObstacle">The distance to the obstacle ahead.</param>
    /// <returns>
    /// <c>true</c> if an emergency brake is needed; otherwise, <c>false</c>.
    /// </returns>
    public bool IsEmergencyBreakNeeded(Length minimalDistance, Speed currentSpeed)
        => (Length.FromMeters(BrakeDistanceCalculatorService.CalculateBrakeDistance(currentSpeed.KilometersPerHour)) + minimalDistance) > DistanceSensorService.GetLength();

}
