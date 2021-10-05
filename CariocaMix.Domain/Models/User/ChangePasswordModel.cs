namespace CariocaMix.Domain.Models.User
{
    public class ChangePasswordModel
    {
        public ChangePasswordModel(long id, string newPassword)
        {
            Id = id;
            NewPassword = newPassword;
        }

        public long Id { get; set; }

        public string NewPassword { get; set; }
    }
}
