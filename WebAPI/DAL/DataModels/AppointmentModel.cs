namespace Domain.DAL
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public DateTime AppointmentTime { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public int? DoctorId { get; set; }
        public int? UserId { get; set; }
    }
}
