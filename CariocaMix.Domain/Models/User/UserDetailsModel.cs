using CariocaMix.Domain.Entities.Base;
using System;

namespace CariocaMix.Domain.Models.User
{
    public class UserDetailsModel : BaseModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public DateTime Birthday { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string NumberPhone { get; set; }

        public long Points { get; set; }

        public string Image { get; set; }
    }
}
