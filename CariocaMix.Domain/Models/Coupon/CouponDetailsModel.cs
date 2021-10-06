using System;

namespace CariocaMix.Domain.Models.Coupon
{
    public class CouponDetailsModel
    {
        public long Id { get; set; }

        public DateTime RegisterDate { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; }

        public decimal? Percentage { get; set; }

        public decimal? Price { get; set; }
    }
}
