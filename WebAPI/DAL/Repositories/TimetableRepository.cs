using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace DAL.Repositories
{
    public class TimetableRepository : ITimetableRepository
    {
        public void Create(Timetable entity)
        {
            throw new NotImplementedException();
        }

        public bool InsertTimetable(Doctor doctor, DateTime startWork, DateTime endWork)
        {
            throw new NotImplementedException();
        }

        public void Delete(Timetable entity)
        {
            throw new NotImplementedException();
        }

        public Timetable Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Timetable> Select()
        {
            throw new NotImplementedException();
        }

        public List<TimeOnly> SelectTimetableOnDate(Doctor doctor, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void Update(Timetable entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTimetable(Doctor doctor, DateTime startWork, DateTime endWork)
        {
            throw new NotImplementedException();
        }
    }
}
