using System.Collections.Generic;

namespace CariocaMix.Utils.Email
{
    public interface ISendEmail
    {
        void SendOneEmail(string subject, string body, string recipient);

        void SendListEmail(string subject, string body, List<string> recipients);
    }
}
