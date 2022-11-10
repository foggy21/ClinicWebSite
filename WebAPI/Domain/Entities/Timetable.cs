namespace Domain.Entities
{
    public class Timetable
    {
        public int? DoctorId { get; set; }
        public DateTime StartWorkDay { get; set; }
        public DateTime EndWorkDay { get; set; }

        public Timetable(int? doctorId, DateTime startWorkDay, DateTime endWorkDay)
        {
            DoctorId = doctorId;
            StartWorkDay = startWorkDay;
            EndWorkDay = endWorkDay;
        }
    }
}
