using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("PaymentStatus")]
    public class PaymentStatus : BaseModel
    {
        public string Name { get; set; }
    }
}
