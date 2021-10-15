using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("DeliveryRemoveArea")]
    public class DeliveryRemoveArea : BaseModel
    {
        [ForeignKey("Store")]
        public long StoreId { get; set; }
        public virtual Store Store { get; set; }

        public int ShapeIndex { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }
    }
}
