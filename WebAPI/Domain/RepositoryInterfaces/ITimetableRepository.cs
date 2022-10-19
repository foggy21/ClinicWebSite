using Domain.Entities;

namespace Domain.RepositoryInterfaces
{
    public interface ITimetableRepository : IBaseRepository<Timetable>
    {
        List<TimeOnly> SelectTimetableOnDate(Doctor doctor, DateOnly date);
        bool InsertTimetable(Doctor doctor, DateTime startWork, DateTime endWork);
        bool UpdateTimetable(Doctor doctor, DateTime startWork, DateTime endWork);
    }
}
