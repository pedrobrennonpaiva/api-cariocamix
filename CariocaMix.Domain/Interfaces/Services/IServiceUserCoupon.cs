using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.UserCoupon;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceUserCoupon
    {
        Result Add(UserCouponAddModel request);

        Result Update(long id, UserCouponUpdateModel request);

        List<UserCouponDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);

        Result ListByUserId(long userId);
    }
}
