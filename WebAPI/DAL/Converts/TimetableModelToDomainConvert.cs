using Domain.DAL;
using Domain.Entities;

namespace DAL.Converts
{
    public static class TimetableModelToDomainConvert
    {
        public static Timetable? ToDomain(this TimetableModel timetableModel)
        {
            return new Timetable(timetableModel.Doctor, timetableModel.StartWorkDay, timetableModel.EndWorkDay)
            {
                Doctor = timetableModel.Doctor,
                StartWorkDay = timetableModel.StartWorkDay,
                EndWorkDay = timetableModel.EndWorkDay
            };
        }
    }
}
