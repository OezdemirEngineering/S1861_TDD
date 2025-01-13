using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.Common.Contracts;

public interface IEmailService
{
    void SendEmail(string recipient, string subject, string body);
}
