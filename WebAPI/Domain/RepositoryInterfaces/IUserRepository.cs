using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User CreateUser(string login, string password, string phone, Role role);
        User GetByLogin(string login);
        bool GetByLoginAndPassword(string login, string password);
        
    }
}
