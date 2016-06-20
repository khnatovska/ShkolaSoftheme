using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserValidator
{
    class Program
    {
        static Validator validator = new Validator();

        static void Main(string[] args)
        {
            while (true)
            {
                Run();
                validator.PrintUsers();
            }
        }    

        static void Run()
        {
            string nameOrEmail;
            string password = String.Empty;
            bool nameGiven = true;
            Console.WriteLine("Enter name or email");
            string nameOrEmailInput = Console.ReadLine();
            if (ExitWanted(nameOrEmailInput) == true)
                Environment.Exit(0);
            else if (nameOrEmailInput.Contains("@"))
            {
                nameGiven = false;
            }
            nameOrEmail = nameOrEmailInput;
            Console.WriteLine("Enter password");
            string passwordInput = Console.ReadLine();
            if (ExitWanted(passwordInput) == true)
                Environment.Exit(0);
            else
            {
                password = passwordInput;
            }
            var user = new User(nameOrEmail, password, nameGiven);
            if (validator.ValidateUser(user) == false)
            {
                validator.AddUser(user);
            }
        }

        static bool ExitWanted(string input)
        {
            if (input == "exit")
                return true;
            return false;
        }


    }
}
