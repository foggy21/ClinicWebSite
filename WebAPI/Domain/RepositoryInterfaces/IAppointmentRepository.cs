using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        bool UpdateAppointment(Doctor doctor, DateTime date);
        bool UpdateAppointmentToAnyDoctor(Specialization specialization, DateTime date);
        List<DateTime> SelectFreeDatesForSpecialization(Specialization specialization);
    }
}
