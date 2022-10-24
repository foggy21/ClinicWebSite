using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        bool CreateAppointment(Doctor doctor, DateTime date);
        bool CreateAppointmentToAnyDoctor(Specialization specialization, DateTime date);
        List<DateTime> SelectDatesForSpecialization(Specialization specialization);
    }
}
