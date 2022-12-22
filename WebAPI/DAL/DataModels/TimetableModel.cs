using Domain.Entities;

namespace Domain.DAL
{
    public class TimetableModel
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime StartWorkDay { get; set; }
        public DateTime EndWorkDay { get; set; }

        public List<Timetable>? FreeTime { get; set; }
    }
}
