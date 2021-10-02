using CariocaMix.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("OrderProductItem")]
    public class OrderProductItem : BaseModel
    {
        [ForeignKey("OrderProduct")]
        public long OrderProductId { get; set; }
        public OrderProduct OrderProduct { get; set; }

        [ForeignKey("ProductItem")]
        public long ProductItemId { get; set; }
        public ProductItem ProductItem { get; set; }
    }
}
