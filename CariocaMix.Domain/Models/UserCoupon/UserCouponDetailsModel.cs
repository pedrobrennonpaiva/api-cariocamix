namespace CariocaMix.Domain.Models.UserCoupon
{
    public class UserCouponDetailsModel
    {
        public long UserId { get; set; }

        public Entities.User User { get; set; }

        public long CouponId { get; set; }

        public bool IsUsed { get; set; }
    }
}
