namespace CariocaMix.Domain.Models.Returns
{
    public class Result
    {
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public Result(bool isSuccess, object returnObject)
        {
            IsSuccess = isSuccess;
            ReturnObject = returnObject;
        }

        public Result(bool isSuccess, string message, object returnObject)
        {
            IsSuccess = isSuccess;
            Message = message;
            ReturnObject = returnObject;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object ReturnObject { get; set; }
    }
}
