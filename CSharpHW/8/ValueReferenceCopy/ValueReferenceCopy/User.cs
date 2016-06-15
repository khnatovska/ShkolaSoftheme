using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueReferenceCopy
{
    class User
    {
        public string Name { get; set; }
        public string Department { get; set; }
        private string Password { get; set; }

        public User(string name, string password, string department)
        {
            Name = name;
            Department = department;
            Password = password;
        }

        public void ChangeDepartment(string department)
        {
            Department = department;
        }

        public string GetDepartment()
        {
            return Department;
        }
    }
}
