using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHell.Contracts;

public interface ILoggerService
{
    void LogError(string message);
    void LogInfo(string message);
    void LogWarning(string message);
}
