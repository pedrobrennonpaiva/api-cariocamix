using CariocaMix.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CariocaMix.Domain.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            if (user != null)
            {
                user.Password = null;
            }
            return user;
        }
        public static IEnumerable<Admin> WithoutPasswords(this IEnumerable<Admin> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static Admin WithoutPassword(this Admin user)
        {
            if (user != null)
            {
                user.Password = null;
            }
            return user;
        }
    }
}
