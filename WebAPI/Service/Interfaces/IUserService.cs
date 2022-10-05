using Domain.Entities;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IUserService
    { 
        Result<bool> CheckUser(string login, string password);
        Result<User> GetUserByLogin(string login);
        Result<User> CreateUser(string login, string password, string phone, Role role);
    }
}
