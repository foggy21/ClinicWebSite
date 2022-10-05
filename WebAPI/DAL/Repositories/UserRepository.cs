using DAL.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(string login, string password, string phone, Role role)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool GetByLoginAndPassword(string login, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Select()
        {
            return (IEnumerable<User>)_db.User.ToListAsync();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
