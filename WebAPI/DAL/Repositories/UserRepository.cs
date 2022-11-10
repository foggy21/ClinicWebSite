using Domain.RepositoryInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Converts;

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
            _db.AddAsync(entity);
            _db.SaveChangesAsync();
        }

        public User CreateUser(string login, string password, string phone, Role role)
        {
            User user = new(login, password, password, role);
            _db.AddAsync(user);
            _db.SaveChangesAsync();
            return user;
        }

        public void Delete(User entity)
        {
            _db.Remove(entity);
            _db.SaveChangesAsync();
        }

        public User Get(int id)
        {
            var user = _db.User.FirstOrDefault(u => u.Id == id);
            return user?.ToDomain();
        }

        public User GetByLogin(string name)
        {
            var user = _db.User.FirstOrDefault(u => u.Name == name);
            return user?.ToDomain();
        }

        public bool GetByLoginAndPassword(string login, string password)
        {
            var user = _db.User.FirstOrDefault(u => (u.Name == login && u.Password == password));
            return true;
        }

        public IEnumerable<User> Select()
        {
            return (IEnumerable<User>)_db.User.ToList();
        }

        public void Update(User entity)
        {
            _db.Update(entity);
            _db.SaveChangesAsync();
        }
    }
}
