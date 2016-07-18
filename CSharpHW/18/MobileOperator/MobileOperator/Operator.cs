using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    public class Operator
    {
        public NumbersFactory AvailableNumbers;
        public List<MobileAccount> RegisteredAccounts;

        public delegate void RegistrationHandler(string message);
        public event RegistrationHandler Registered;

        public Operator()
        {
            AvailableNumbers = new NumbersFactory(100);
            RegisteredAccounts = new List<MobileAccount>();
            Registered += PrintMessage;
        }

        public MobileAccount RegisterAccount()
        {
            var number = AvailableNumbers.GetAvailableNumber();
            var account = new MobileAccount(number);
            account.Calling += MonitorEvents;
            account.SendingMessage += MonitorEvents;
            account.Calling += RouteCall;
            account.SendingMessage += RouteMessage;
            RegisteredAccounts.Add(account);
            if (Registered != null)
            {
                Registered(string.Format("New account with number {0} has been registered.", account.Number));
            }
            return account;
        }

        public void RouteCall(object sender, MobileAccountEventsArgs e)
        {
            foreach (var registeredAccount in RegisteredAccounts)
            {
                if (registeredAccount.Number.Equals(e.CalledNumber))
                {
                    Console.WriteLine("Operator is routing a call: called mobile account {0} is registered.", e.CalledNumber);
                    registeredAccount.ReceiveCall(sender, e);
                    return;
                }
            }
            Console.WriteLine("Operator is routing a call: called mobile account {0} is not registered. Routing failed.", e.CalledNumber);
        }

        public void RouteMessage(object sender, MobileAccountEventsArgs e)
        {
            foreach (var registeredAccount in RegisteredAccounts)
            {
                if (registeredAccount.Number.Equals(e.CalledNumber))
                {
                    Console.WriteLine("Operator is routing a message: addressed mobile account {0} is registered.", e.CalledNumber);
                    registeredAccount.ReceiveMessage(sender, e);
                    return;
                }
            }
            Console.WriteLine("Operator is routing a message: addressed mobile account {0} is not registered. Routing failed.", e.CalledNumber);
        }

        public void MonitorEvents(object sender, MobileAccountEventsArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
