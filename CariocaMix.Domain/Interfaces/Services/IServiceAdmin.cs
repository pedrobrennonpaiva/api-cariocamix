using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Admin;
using System.Collections.Generic;
using CariocaMix.Domain.Models.User;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceAdmin
    {
        Result Authenticate(AuthenticateModel model);

        Result ChangePassword(ChangePasswordModel model);

        Result Add(AdminAddModel request);

        Result Update(AdminUpdateModel request);

        List<AdminDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
