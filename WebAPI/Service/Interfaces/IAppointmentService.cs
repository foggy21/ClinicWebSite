using Domain.Entities;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IAppointmentService
    {
        Result<bool> SaveAppointment(Doctor doctor, DateTime date);
        Result<bool> SaveAppointmentToAnyDoctor(Specialization specialization, DateTime date);
        Result<List<DateTime>> GetFreeDatesForSpecialization(Specialization specialization);
    }
}
