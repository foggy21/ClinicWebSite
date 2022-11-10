using DAL.Converts;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace DAL.Repositories
{
    public class TimetableRepository : ITimetableRepository
    {
        private readonly ApplicationDbContext _db;

        public TimetableRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(Timetable entity)
        {
            _db.AddAsync(entity);
            _db.SaveChangesAsync();
        }

        public bool InsertTimetable(Doctor doctor, DateTime startWork, DateTime endWork)
        {
            Timetable timetable = new(doctor.Id, startWork, endWork);
            _db.AddAsync(timetable);
            _db.SaveChangesAsync();
            return true;
        }

        public void Delete(Timetable entity)
        {
            _db.Remove(entity);
            _db.SaveChangesAsync();
        }

        public Timetable Get(int id)
        {
            var timetable = _db.Timetable.FirstOrDefault(tt => tt.DoctorId == id);
            return timetable?.ToDomain();
        }

        public IEnumerable<Timetable> Select()
        {
            return (IEnumerable<Timetable>)_db.Timetable.ToList();
        }

        public List<TimeOnly> SelectTimetableOnDate(Doctor doctor, DateOnly date)
        {
            List<TimeOnly> freeTimes = new();
            var timetables = _db.Timetable.ToList();
            var doc = _db.Doctor.FirstOrDefault(d => d.Id == doctor.Id);
            for (int i = 0; i < timetables.Count; i++)
            {
                if (doc.Id == timetables[i].DoctorId)
                {
                    freeTimes =  timetables[i]?.FreeTime;
                }
            }
            return freeTimes;
        }

        public void Update(Timetable entity)
        {
            _db.Update(entity);
            _db.SaveChangesAsync();
        }

        public bool UpdateTimetable(Doctor doctor, DateTime startWork, DateTime endWork)
        {
            Timetable timetable = new(doctor.Id, startWork, endWork);
            _db.Update(timetable);
            _db.SaveChangesAsync();
            return true;
        }
    }
}
