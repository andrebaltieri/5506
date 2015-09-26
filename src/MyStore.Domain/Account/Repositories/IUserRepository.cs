using MyStore.Domain.Account.Entities;

namespace MyStore.Domain.Account.Repositories
{
    public interface IUserRepository
    {
        void Save(User user);
        void Update(User user);
        User GetUserByUsername(string username);
        User GetByAuthorizationCode(string authorizationCode);
    }
}
