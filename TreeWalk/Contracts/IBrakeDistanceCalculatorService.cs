using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHell.Contracts;

public interface IBrakeDistanceCalculatorService
{
    ILoggerService Logger { get; }
    IFrictionService FrictionService { get; }
    double CalculateBrakeDistance(double initialSpeed);
}
