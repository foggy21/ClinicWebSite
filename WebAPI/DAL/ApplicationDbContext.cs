using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Optional.
            Database.EnsureCreated();
        }
        public DbSet<User> User { get; set; }
    }
}