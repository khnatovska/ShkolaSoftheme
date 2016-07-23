using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConsoleLibrary
{
    public class AnonimousUser : User
    {
        public AnonimousUser()
            :base("none", "none", true)
        {
            IsAuthorized = false;
        }

        public override string GetFullInfo()
        {
            return "Anonym";
        }
    }
}
