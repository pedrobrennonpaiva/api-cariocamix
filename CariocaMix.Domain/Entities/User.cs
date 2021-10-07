using CariocaMix.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("User")]
    public class User : BaseModel
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
