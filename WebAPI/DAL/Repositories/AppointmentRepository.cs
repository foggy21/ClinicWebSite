using Domain.Entities;
using Domain.RepositoryInterfaces;
using DAL.Converts;
using Microsoft.EntityFrameworkCore;
using Domain.DAL;
using System.Numerics;

namespace DAL.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _db;

        public AppointmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(Appointment entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Appointment entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public Appointment? Get(int id)
        {
            var appointment = _db.Appointments.FirstOrDefault(a => a.UserId == id);
            return appointment?.ToDomain();
        }

        public List<DateTime> SelectDatesForSpecialization(Specialization specialization)
        {
            List<DateTime> dateTimes = new List<DateTime>();
            var doctor = _db.Doctor.FirstOrDefault(doc => doc.specialization.Id == specialization.Id);
            var appointmentForSpecialization = _db.Appointments.ToList();
            for (int i = 0; i < appointmentForSpecialization.Count; ++i)
            {
                if (_db.Appointments.FirstOrDefault(a => doctor.Id == appointmentForSpecialization[i].DoctorId) != null)
                {
                    dateTimes.Add(appointmentForSpecialization[i].AppointmentTime);
                }
            }
            return dateTimes;
        }

        public IEnumerable<Appointment> Select()
        {
            return (IEnumerable<Appointment>)_db.Appointments.ToList();
        }

        public void Update(Appointment entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }

        public bool CreateAppointment(Doctor doctor, DateTime date)
        {
            var appointment = _db.Appointments.FirstOrDefault(a => a.DoctorId == doctor.Id);
            appointment.AppointmentTime = date;
            _db.Add(appointment);
            _db.SaveChanges();
            return true;
        }

        public bool CreateAppointmentToAnyDoctor(Specialization specialization, DateTime date)
        {
            var doctor = _db.Doctor.FirstOrDefault(doc => (doc.specialization.Id == specialization.Id));
            var appointment = _db.Appointments.FirstOrDefault(a => (a.DoctorId == doctor.Id) && (a.StartDay <= date && date <= a.EndDay));
            if (appointment != null)
            {
                appointment.AppointmentTime = date;
                _db.Add(appointment);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
