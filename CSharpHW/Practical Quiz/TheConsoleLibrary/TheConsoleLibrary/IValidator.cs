using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    public interface IValidator
    {
        bool ValidateUser(IUser user);
    }
}
