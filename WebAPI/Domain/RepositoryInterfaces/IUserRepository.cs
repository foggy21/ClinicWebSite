using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User CreateUser(string login, string password, string phone, Role role);
        User CreateUser(User user);
        User GetByLogin(string login);
        bool GetByLoginAndPassword(string login, string password);
        
    }
}
