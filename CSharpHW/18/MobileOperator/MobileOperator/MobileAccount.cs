using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    public class MobileAccount
    {
        public delegate void ActionHandler(object sender, MobileAccountEventsArgs e);
        public event ActionHandler Calling;
        public event ActionHandler SendingMessage;

        public MobileNumber Number { get; }
        public decimal Balance { get; }
        public Dictionary<MobileNumber, string> Phonebook;
        
        public MobileAccount(MobileNumber number)
        {
            Balance = 0;
            Number = number;
            Phonebook = new Dictionary<MobileNumber, string>();
        }

        public void SaveNumber(MobileNumber number, string name)
        {
            if (Phonebook.ContainsKey(number) == false)
            {
                Phonebook.Add(number, name);
                Console.WriteLine("{0} is saved as {1}", number, name);
            }
            else
            {
                var previousName = Phonebook[number];
                Phonebook[number] = name;
                Console.WriteLine("{0} formerly known as {1} is overwritten as {2}", number, previousName, name);
            }
            
        }

        public void Call(string number)
        {
            if (ValidateNumber(number) == true)
            {
                if (Calling != null)
                {
                    Calling(this, new MobileAccountEventsArgs(Number, new MobileNumber(number),
                        string.Format("Account {0} is calling number {1}", Number, number)));
                }
            }
        }

        public void SendMessage(string number, string textMessage)
        {
            if (ValidateNumber(number) == true)
            {
                if (SendingMessage != null)
                {
                    SendingMessage(this, new MobileAccountEventsArgs(Number, new MobileNumber(number),
                        string.Format("Account {0} is sending number {1} a message", Number, number), textMessage));
                }
            }
        }
        
        public void ReceiveCall(object sender, MobileAccountEventsArgs e)
        {
            var incomingNumber = FindInPhonebook(e.CallingNumber);
            Console.WriteLine("Account {0} is receiving a call from {1}", Number, incomingNumber);
        }

        public void ReceiveMessage(object sender, MobileAccountEventsArgs e)
        {
            var incommingNumber = FindInPhonebook(e.CallingNumber);
            Console.WriteLine("Account {0} has received a message from {1}: \" {2} \"", Number, incommingNumber, e.Text);
        }

        public string FindInPhonebook(MobileNumber number)
        {
            string checkedNumber;
            if (Phonebook.ContainsKey(number))
            {
                checkedNumber = Phonebook[number];
            }
            else
            {
                checkedNumber = number.ToString();
            }
            return checkedNumber;
        }

        public bool ValidateNumber(string number)
        {
            try
            {
                long.Parse(number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect number " + number);
                return false;
            }
            if (number.Length != 12 && number.Substring(0, 5) != "38066")
            {
                Console.WriteLine("Incorrect number " + number);
                return false;
            }
            return true;
        }

        public void Print()
        {
            Console.WriteLine("Number: {0}. Balance: {1}", Number, Balance);
        }
        
        public string Callable()
        {
            return Number.GetFullNumber();
        }
    }
}
