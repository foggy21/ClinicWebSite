using Domain.DAL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<DoctorModel> Doctor { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }
        public DbSet<TimetableModel> Timetable { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=clinicdb;Username=postgres;Password=#Foggy38515825");
        }
    }
}
