using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace ServiceHell.Contracts;

public interface IDistanceSensorService
{
    ILoggerService LoggerService { get;}
    Length GetLength();
}
