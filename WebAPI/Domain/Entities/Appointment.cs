namespace Domain.Entities
{
    class Appointment
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int doctorId { get; set; }
        public int userId { get; set; }
    }
}
