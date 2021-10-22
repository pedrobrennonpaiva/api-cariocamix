using System;

namespace CariocaMix.Domain.Models.Admin
{
    public class AdminAddModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public DateTime Birthday { get; set; }

        public string NumberPhone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }

        public bool IsRoot { get; set; }

        public long? StoreId { get; set; }
    }
}
