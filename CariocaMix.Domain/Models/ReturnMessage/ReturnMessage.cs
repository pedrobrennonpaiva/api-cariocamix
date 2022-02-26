namespace CariocaMix.Domain.Models.ReturnMessage
{
    public class ReturnMessage
    {
        public ReturnMessage()
        {
        }

        public ReturnMessage(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
