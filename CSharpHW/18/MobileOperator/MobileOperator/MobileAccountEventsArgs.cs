namespace MobileOperator
{
    public class MobileAccountEventsArgs
    {
        public MobileNumber CallingNumber { get; set; }
        public MobileNumber CalledNumber { get; set; }
        public string Message { get; set; }
        public string Text { get; set; }

        public MobileAccountEventsArgs(MobileNumber caller, MobileNumber receiver, string message, string text = null)
        {
            CallingNumber = caller;
            CalledNumber = receiver;
            Message = message;
            if (text != null)
            {
                Text = text;
            }
        }
    }
}