using Domain.DAL;
using Domain.Entities;

namespace DAL.Converts
{
    public static class AppointmentModelToDomainConverter
    {
        public static Appointment? ToDomain(this AppointmentModel appointment)
        {
            return new Appointment
            {
                UserId = appointment.UserId,
                DoctorId = appointment.DoctorId,
                StartDate = appointment.StartDay,
                EndDate = appointment.EndDay
            };
        }
    }
}
