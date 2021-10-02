namespace CariocaMix.Utils.Validations
{
    public static class RegularExpressionsValidator
    {
        // regex of the password with minimum 8 caracters, minimum 1 special caracter, 1 uppercase letter,
        // 1 lowercase letter and 1 number.
        public const string Password = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])[0-9a-zA-Z$*&@#]{8,}$";

        public const string PasswordEightCharacters = @"^.{8,}$";

        public const string Email = "";

        public const string Cpf = "";
    }
}
