namespace Domain.DAL
{
    public class Appointment
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? DoctorId { get; set; }
        public int? UserId { get; set; }
    }
}
