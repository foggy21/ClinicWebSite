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
        public DbSet<SpecializationModel> Specializations { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>().HasIndex(model => model.Name);
        }
    }
}
