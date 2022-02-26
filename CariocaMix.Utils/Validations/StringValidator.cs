using System.Linq;
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

        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsCpf(string cpf)
        {
            if(string.IsNullOrEmpty(cpf))
            {
                return false;
            }

            if(cpf.Distinct().Count() == 1)
            {
                return false;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
