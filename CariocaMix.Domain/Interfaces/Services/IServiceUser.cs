using CariocaMix.Domain.Models.ReturnMessage;
using CariocaMix.Domain.Models.User;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceUser
    {
        ReturnMessageResponse Authenticate(AuthenticateModel model);

        ReturnMessageResponse ChangePassword(ChangePasswordModel model);

        ReturnMessageResponse Add(UserAddModel request);

        ReturnMessageResponse Update(long id, UserUpdateModel request);

        List<UserDetailsModel> List();

        ReturnMessageResponse Delete(long id);

        ReturnMessageResponse GetById(long id);

        ReturnMessageResponse ListByName(string name);

        ReturnMessageResponse ListBySearch(string search);
    }
}
