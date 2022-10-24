using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IDoctorService
    {
        Result<List<Doctor>> GetDoctors();
        Result<bool> DeleteDoctor(Doctor doctor);
        Result<Doctor> CreateDoctor(string? name, Specialization specialization);
        Result<Doctor> GetDoctorById(int? id);
        Result<Doctor> GetDoctorBySpecialization(Specialization specialization);
    }
}
