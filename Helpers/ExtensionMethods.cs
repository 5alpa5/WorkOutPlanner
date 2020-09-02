using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<Users> WithoutPasswords(this IEnumerable<Users> users) 
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static Users WithoutPassword(this Users user) 
        {
            if (user == null) return null;

            user.Password = null;
            return user;
        }
    }
}