using Domain.Entities;
using Domain.Response;

namespace Service.Interfaces
{
    public interface ITimetableService
    {
        Result<List<Timetable>> GetTimeTable(Doctor doctor, DateOnly date);
        Result<bool> AddTimeTable(Doctor doctor, DateTime startWork, DateTime endWork);
        Result<bool> EditTimeTable(Doctor doctor, DateTime startWork, DateTime endWork);
    }
}
