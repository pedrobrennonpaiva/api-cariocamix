using System.Collections.Generic;

namespace CariocaMix.Domain.Models.ReturnMessage
{
    public class ReturnMessageResponse
    {
        public ReturnMessageResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public ReturnMessageResponse(bool isSuccess, object returnObject)
        {
            IsSuccess = isSuccess;
            ReturnObject = returnObject;
        }

        public ReturnMessageResponse(bool isSuccess, List<ReturnMessage> errors, object returnObject)
        {
            IsSuccess = isSuccess;
            Errors = errors;
            ReturnObject = returnObject;
        }

        public ReturnMessageResponse(bool isSuccess, List<ReturnMessage> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public ReturnMessageResponse(bool isSuccess, int code, string message)
        {
            IsSuccess = isSuccess;
            Errors = new List<ReturnMessage>() { new ReturnMessage(code, message) };
        }

        public ReturnMessageResponse(bool isSuccess, int code, string message, object returnObject)
        {
            IsSuccess = isSuccess;
            Errors = new List<ReturnMessage>() { new ReturnMessage(code, message) };
            ReturnObject = returnObject;
        }

        public bool IsSuccess { get; set; }

        public List<ReturnMessage> Errors { get; set; }

        public object ReturnObject { get; set; }
    }
}
