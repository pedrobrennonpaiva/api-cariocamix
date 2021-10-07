using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("PaymentType")]
    public class PaymentType : BaseModel
    {
        public string Name { get; set; }
    }
}
