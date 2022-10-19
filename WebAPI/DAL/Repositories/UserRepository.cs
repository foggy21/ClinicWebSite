using Domain.RepositoryInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(string login, string password, string phone, Role role)
        {
            throw new NotImplementedException();
            // TODO:
            // Вставить в БД соответствующие поля из аргуменов
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByLogin(string name)
        {
            // TODO:
            // 1. Заправшивать у базы данных соответсвующий логин из параметра.
            // 2. Если логина нет - вернуть null.
            // 3. Если логин есть - создать объект User и передать ему поля из таблицы.
            // 4. Вернуть объект User.
            throw new NotImplementedException();
        }

        public bool GetByLoginAndPassword(string login, string password)
        {
            // TODO:
            // 1. Запрашивать у базы данных соответсвующий логин и пароль из параметра.
            // 2. Если не совпал логин - вернуть false.
            // 3. Захешировать пароль из параметра.
            // 4. Проверить хеш пароля из параметра с хешом пароля из БД.
            // 5. Если хеши не совпали - вернуть false.
            // 6. Вернуть true.
            throw new NotImplementedException();
        }

        public IEnumerable<User> Select()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
