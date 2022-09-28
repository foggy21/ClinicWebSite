namespace Domain.Entities
{
    class Timetable
    {
        public int doctorId { get; set; }
        public DateTime startWorkDay { get; set; }
        public DateTime endWorkDay { get; set; }
    }
}
