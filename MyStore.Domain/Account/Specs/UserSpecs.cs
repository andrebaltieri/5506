using MyStore.Domain.Account.Entities;
using System;
using System.Linq.Expressions;

namespace MyStore.Domain.Account.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> GetByUsername(string username)
        {
            return x => x.Username == username;
        }

        public static Expression<Func<User, bool>> GetByAuthorizationCode(string authorizationCode)
        {
            return x => x.AuthorizationCode == authorizationCode;
        }
    }
}
