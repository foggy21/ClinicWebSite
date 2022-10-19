using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Doctor CreateDoctor(string? name, Specialization specialization);
        Doctor FindDoctorById(int? id);
        Doctor FindDoctorBySpecialization(Specialization specialization);
    }
}
