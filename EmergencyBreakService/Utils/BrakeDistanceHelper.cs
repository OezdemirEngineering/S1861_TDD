using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyBrakeService.Utils;

public static class BrakeDistanceHelper
{
    public const double Gravity = 9.81;
    public static double CalculateBrakeDistance(double initialSpeed, double frictionCoefficient)
        => Math.Pow(initialSpeed, 2) / (2 * Gravity * frictionCoefficient);
}
