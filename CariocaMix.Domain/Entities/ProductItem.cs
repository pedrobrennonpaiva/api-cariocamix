using CariocaMix.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("ProductItem")]
    public class ProductItem : BaseModel
    {
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Item")]
        public long ItemId { get; set; }
        public virtual Item Item { get; set; }

        public bool IsDefault { get; set; }

        public decimal Price { get; set; }
    }
}
