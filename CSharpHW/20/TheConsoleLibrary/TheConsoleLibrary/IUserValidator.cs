using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    public interface IUserValidator
    {
        bool ValidateUser(IUser user);
    }
}
