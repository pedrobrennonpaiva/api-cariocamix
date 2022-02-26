using CariocaMix.Domain.Models.ReturnMessage;
using Newtonsoft.Json;

namespace CariocaMix.Utils.Converts
{
    public static class ConvertReturnMessage
    {
        public static string SerializeReturnMessage(int code, string message)
        {
            return JsonConvert.SerializeObject(new ReturnMessage(code, message));
        }
    }
}
