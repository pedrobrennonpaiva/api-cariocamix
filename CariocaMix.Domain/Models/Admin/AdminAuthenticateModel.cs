using CariocaMix.Domain.Entities.Base;
using System;

namespace CariocaMix.Domain.Models.Admin
{
    public class AdminAuthenticateModel : BaseModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public DateTime Birthday { get; set; }

        public string NumberPhone { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }

        public bool IsRoot { get; set; }

        public long? StoreId { get; set; }

        public string Token { get; set; }

        public DateTime? TokenExpires { get; set; }

        public static explicit operator AdminAuthenticateModel(Entities.Admin admin)
        {
            AdminAuthenticateModel userAuthenticate = new AdminAuthenticateModel()
            {
                Id = admin.Id,
                Name = admin.Name,
                Username = admin.Username,
                Birthday = admin.Birthday,
                NumberPhone = admin.NumberPhone,
                Email = admin.Email,
                Image = admin.Image,
                IsActive = admin.IsActive,
                IsRoot = admin.IsRoot,
                StoreId = admin.StoreId,
            };

            return userAuthenticate;
        }
    }
}
