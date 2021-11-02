using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("Address")]
    public class Address : BaseModel
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public string Cep { get; set; }

        public string AddressText { get; set; }

        public string Complement { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }
    }
}
