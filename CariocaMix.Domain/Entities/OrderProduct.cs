using CariocaMix.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("OrderProduct")]
    public class OrderProduct : BaseModel
    {
        [ForeignKey("Order")]
        public long OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public string Obs { get; set; }
    }
}
