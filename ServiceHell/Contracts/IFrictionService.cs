using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHell.Contracts;

public interface IFrictionService
{
    double GetFriction();
    ILoggerService Logger { get; }
}
