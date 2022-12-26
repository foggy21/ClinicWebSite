namespace Domain.DAL
{
    public class TimetableModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartWorkDay { get; set; }
        public DateTime EndWorkDay { get; set; }

        public List<TimeOnly>? FreeTime { get; set; }
    }
}
