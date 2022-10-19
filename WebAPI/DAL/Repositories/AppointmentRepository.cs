using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace DAL.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public void Create(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public Appointment Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DateTime> SelectFreeDatesForSpecialization(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> Select()
        {
            throw new NotImplementedException();
        }

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAppointment(Doctor doctor, DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAppointmentToAnyDoctor(Specialization specialization, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
