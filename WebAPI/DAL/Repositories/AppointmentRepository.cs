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

        public List<DateTime> SelectDatesForSpecialization(Specialization specialization)
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

        public bool CreateAppointment(Doctor doctor, DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool CreateAppointmentToAnyDoctor(Specialization specialization, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
