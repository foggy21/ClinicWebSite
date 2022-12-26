namespace Domain.Entities
{
    public class Timetable
    {
        public Doctor Doctor { get; set; }
        public DateTime StartWorkDay { get; set; }
        public DateTime EndWorkDay { get; set; }

        public Timetable(Doctor doctor, DateTime startWorkDay, DateTime endWorkDay)
        {
            Doctor = doctor;
            StartWorkDay = startWorkDay;
            EndWorkDay = endWorkDay;
        }
    }
}
