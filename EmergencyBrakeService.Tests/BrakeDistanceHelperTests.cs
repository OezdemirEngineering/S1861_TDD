using EmergencyBrakeService.Utils;

namespace EmergencyBrakeService.Tests;

public class BrakeDistanceHelperTests
{

    [Theory]
    [InlineData(10, 1, 5.097)]
    [InlineData(100, 1, 509.68)]
    public void CalculateBrakeDistance_InlineParams_CorrectDistance(double speed, double frictionCoeffizient, double expectedDistance)
    {

        //Act
        var distance = BrakeDistanceHelper.CalculateBrakeDistance(speed, frictionCoeffizient);
        
        //Assert
        Assert.Equal(expectedDistance, distance, 2);
    }
}
