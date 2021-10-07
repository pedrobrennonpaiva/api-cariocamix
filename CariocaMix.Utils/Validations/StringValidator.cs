using System.Text;
using System.Text.RegularExpressions;

namespace CariocaMix.Utils.Validations
{
    public class StringValidator
    {
        public static string ValidatePassword(string password)
        {
            var reg = new Regex(RegularExpressionsValidator.Password);
            if (!reg.IsMatch(password))
            {
                return string.Format(Resources.Message.A_X0_DEVE_CONTER_X1,
                                     "senha",
                                     "no mínimo 8 caracteres, com pelo menos uma letra maiúscula, um número e um caracter especial");
            }

            return string.Empty;
        }

        public static string ValidatePasswordEightCharacters(string password)
        {
            var reg = new Regex(RegularExpressionsValidator.PasswordEightCharacters);
            if (!reg.IsMatch(password))
            {
                return string.Format(Resources.Message.A_X0_DEVE_CONTER_X1,
                                     "senha",
                                     "no mínimo 8 caracteres");
            }

            return string.Empty;
        }

        public static string ReplaceString(string s)
        {
            StringBuilder sb = new StringBuilder(s.Trim());

            sb.Replace(" ", string.Empty);
            sb.Replace("(", string.Empty);
            sb.Replace(")", string.Empty);
            sb.Replace("-", string.Empty);
            sb.Replace(".", string.Empty);

            return sb.ToString().ToLower();
        }

        public static bool NumberPhoneIsValid(string numberPhone)
        {
            Regex regex = new Regex(@"\(\d{2}\)\s\d{5}\-\d{4}");

            return regex.IsMatch(numberPhone);
        }
    }
}
