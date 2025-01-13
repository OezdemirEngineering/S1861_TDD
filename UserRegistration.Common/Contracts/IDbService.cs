using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.Common.Contracts;

public interface IDbService
{
    void SaveUser(string username, string password);
    void DeleteUser(string username);
    bool UserExists(string username);
}
