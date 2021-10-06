namespace CariocaMix.Domain.Models.Coupon
{
    public class CouponUpdateModel
    {
        public string Code { get; set; }

        public bool IsActive { get; set; }

        public decimal? Percentage { get; set; }

        public decimal? Price { get; set; }
    }
}
