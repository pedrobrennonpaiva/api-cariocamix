using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Coupon;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceCoupon
    {
        Result Add(CouponAddModel request);

        Result Update(long id, CouponUpdateModel request);

        List<CouponDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);

        Result GetByCode(string code);
    }
}
