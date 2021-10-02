using CariocaMix.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("Order")]
    public class Order : BaseModel
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Coupon")]
        public long? CouponId { get; set; }
        public Coupon Coupon { get; set; }

        [ForeignKey("PaymentType")]
        public long PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        [ForeignKey("PaymentStatus")]
        public long? PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        [ForeignKey("DeliveryStatus")]
        public long? DeliveryStatusId { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }

        [ForeignKey("DeliveryTax")]
        public long DeliveryTaxId { get; set; }
        public DeliveryTax DeliveryTax { get; set; }

        public decimal Total { get; set; }
    }
}
