using CariocaMix.Domain.Entities.Base;
using System;

namespace CariocaMix.Domain.Models.User
{
    public class UserAuthenticateModel : BaseModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public DateTime Birthday { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string NumberPhone { get; set; }

        public long Points { get; set; }

        public string Image { get; set; }

        public string Token { get; set; }

        public DateTime? TokenExpires { get; set; }

        public static explicit operator UserAuthenticateModel(Entities.User user)
        {
            UserAuthenticateModel userAuthenticate = new UserAuthenticateModel()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Birthday = user.Birthday,
                Cpf = user.Cpf,
                Email = user.Email,
                NumberPhone = user.NumberPhone,
                Points = user.Points,
                Image = user.Image,
            };

            return userAuthenticate;
        }
    }
}
