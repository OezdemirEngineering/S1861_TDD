
using EmergencyBrakeService.Services;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using ServiceHell.Contracts;

namespace ServiceHell.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var services = new ServiceCollection();

        var mockLogger = Substitute.For<ILoggerService>();

        services.AddSingleton<ILoggerService>(mockLogger);
        services.AddTransient<IBrakeDistanceCalculatorService, BrakeDistanceService>();
        services.AddTransient<BrakeService>();



    }
}
