using CariocaMix.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("Admin")]
    public class Admin : BaseModel
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
