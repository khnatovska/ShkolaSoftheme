using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserValidator
{
    public interface IValidator
    {
        bool ValidateUser(IUser user);
    }
}
