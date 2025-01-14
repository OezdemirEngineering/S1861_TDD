

using NSubstitute;
using NSubstitute.Core.Arguments;
using UnitsNet;

namespace EmergencyBrakeService.Tests;

public class BrakeServiceTests
{
    private readonly BrakeService _brakeService;
    private readonly Length _minimalDistance;
    private readonly Speed _currentSpeed;
    private readonly double _frictionCoefficient;

    public BrakeServiceTests()
    {
        _minimalDistance = Length.FromMeters(10);
        _currentSpeed = Speed.FromKilometersPerHour(10);
        _frictionCoefficient = 1;

        _brakeService = new BrakeService(_minimalDistance, _currentSpeed, _frictionCoefficient);
    }



    [Fact]
    public void BrakeService_ConstructorParams_CorrectProperties()
    {
        //Arrange

        //Assert
        Assert.Equal(_minimalDistance, _brakeService.MinimalDistance);
        Assert.Equal(_currentSpeed, _brakeService.CurrentSpeed);
        Assert.Equal(_frictionCoefficient, _brakeService.FrictionCoefficient);
    }

    [Fact]
    public void UpdateSpeed_NewSpeed_CorrectSpeed()
    {
        //Arrange
        var newSpeed = Speed.FromKilometersPerHour(20);

        //Act
        _brakeService.UpdateSpeed(newSpeed);

        //Assert
        Assert.Equal(newSpeed, _brakeService.CurrentSpeed);
    }

    [Fact]
    public void UpdateSpeed_NegativeSpeed_ThrowsArgumentOutOfRangeException()
    {
        //Arrange
        var newSpeed = Speed.FromKilometersPerHour(-20);

        // Act Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _brakeService.UpdateSpeed(newSpeed));
        Assert.Equal(_currentSpeed, _brakeService.CurrentSpeed);
    }

    [Fact]
    public void UpdateFrictionCoefficient_NewFrictionCoefficient_CorrectFrictionCoefficient()
    {
        //Arrange
        var newFrictionCoefficient = 2;

        //Act
        _brakeService.UpdateFrictionCoefficient(newFrictionCoefficient);

        //Assert
        Assert.Equal(newFrictionCoefficient, _brakeService.FrictionCoefficient);
    }

    [Fact]
    public void UpdateFrictionCoefficient_NegativeFrictionCoefficient_ThrowsArgumentOutOfRangeException()
    {
        //Arrange
        var newFrictionCoefficient = -2;

        // Act Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _brakeService.UpdateFrictionCoefficient(newFrictionCoefficient));
        Assert.Equal(_frictionCoefficient, _brakeService.FrictionCoefficient);
    }

    [Fact]
    public void IsEmergencyBreakNeeded_DistanceToObstacle_ReturnsCorrectValue()
    {
        //Arrange
        var distanceToObstacle = Length.FromMeters(5);

        //Act
        var result = _brakeService.IsEmergencyBreakNeeded(distanceToObstacle);

        //Assert
        Assert.True(result);
    }
}
