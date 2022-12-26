using DAL.Converts;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace DAL.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly ApplicationDbContext _db;

        public DoctorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(Doctor entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public Doctor CreateDoctor(string? name, Specialization specialization)
        {
            Doctor doctor = new(name, specialization);
            _db.Add(doctor);
            _db.SaveChanges();
            return doctor;
        }

        public void Delete(Doctor entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public Doctor FindDoctorById(int? id)
        {
            var doctor = _db.Doctor.FirstOrDefault(doc => doc.Id == id);
            return doctor?.ToDomain();
        }

        public Doctor FindDoctorBySpecialization(Specialization specialization)
        {
            var doctor = _db.Doctor.FirstOrDefault(doc => doc.specialization.ToDomain() == specialization);
            return doctor?.ToDomain();
        }

        public Doctor Get(int id)
        {
            var doctor = _db.Doctor.FirstOrDefault(doc => doc.Id == id);
            return doctor?.ToDomain();
        }

        public IEnumerable<Doctor> Select()
        {
            return (IEnumerable<Doctor>)_db.Doctor.ToList();
        }

        public void Update(Doctor entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }
    }
}
