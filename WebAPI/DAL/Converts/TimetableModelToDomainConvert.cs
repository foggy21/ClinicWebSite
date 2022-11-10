using Domain.DAL;
using Domain.Entities;

namespace DAL.Converts
{
    public static class TimetableModelToDomainConvert
    {
        public static Timetable? ToDomain(this TimetableModel timetableModel)
        {
            return new Timetable(timetableModel.DoctorId, timetableModel.StartWorkDay, timetableModel.EndWorkDay)
            {
                DoctorId = timetableModel.DoctorId,
                StartWorkDay = timetableModel.StartWorkDay,
                EndWorkDay = timetableModel.EndWorkDay
            };
        }
    }
}
