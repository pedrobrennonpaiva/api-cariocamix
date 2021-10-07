using CariocaMix.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CariocaMix.Domain.Entities
{
    [Table("UserCoupon")]
    public class UserCoupon : BaseModel
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Coupon")]
        public long CouponId { get; set; }
        public virtual Coupon Coupon { get; set; }

        public bool IsUsed { get; set; }
    }
}
