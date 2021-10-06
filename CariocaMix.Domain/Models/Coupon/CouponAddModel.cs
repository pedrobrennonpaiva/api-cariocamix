namespace CariocaMix.Domain.Models.Coupon
{
    public class CouponAddModel
    {
        public string Code { get; set; }

        public bool IsActive { get; set; }

        public decimal? Percentage { get; set; }

        public decimal? Price { get; set; }
    }
}
