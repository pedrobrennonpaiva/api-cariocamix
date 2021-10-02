using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("DeliveryStatus")]
    public class DeliveryStatus : BaseModel
    {
        public string Name { get; set; }
    }
}
