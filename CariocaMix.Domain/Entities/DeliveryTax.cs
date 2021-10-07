using CariocaMix.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("DeliveryTax")]
    public class DeliveryTax : BaseModel
    {
        [ForeignKey("Store")]
        public long StoreId { get; set; }
        public virtual Store Store { get; set; }

        public decimal Radius { get; set; }

        public decimal Price { get; set; }
    }
}
