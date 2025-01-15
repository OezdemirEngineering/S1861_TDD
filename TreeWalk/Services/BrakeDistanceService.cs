using ServiceHell.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyBrakeService.Services;

public class BrakeDistanceService(IFrictionService frictionService,ILoggerService logger) : IBrakeDistanceCalculatorService
{
    public ILoggerService Logger => logger;
    public IFrictionService FrictionService => frictionService;

    public const double Gravity = 9.81;
    public double CalculateBrakeDistance(double initialSpeed)
        => Math.Pow(initialSpeed, 2) / (2 * Gravity * FrictionService.GetFriction());
}
