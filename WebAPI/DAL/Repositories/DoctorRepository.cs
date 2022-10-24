using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace DAL.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        public void Create(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public Doctor CreateDoctor(string? name, Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public Doctor FindDoctorById(int? id)
        {
            throw new NotImplementedException();
        }

        public Doctor FindDoctorBySpecialization(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public Doctor Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> Select()
        {
            throw new NotImplementedException();
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
