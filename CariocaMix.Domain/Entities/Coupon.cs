using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("Coupon")]
    public class Coupon : BaseModel
    {
        public string Code { get; set; }

        public bool IsActive { get; set; }

        public decimal? Percentage { get; set; }

        public decimal? Price { get; set; }
    }
}
