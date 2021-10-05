using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.User;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceUser
    {
        Result Authenticate(AuthenticateModel model);

        Result ChangePassword(ChangePasswordModel model);

        Result Add(UserAddModel request);

        Result Update(long id, UserUpdateModel request);

        List<UserDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
