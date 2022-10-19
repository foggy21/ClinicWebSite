using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.Response;
using Service.Interfaces;

namespace Service.Implementations
{
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _timetableRepository;

        public TimetableService(ITimetableRepository timetableRepository)
        {
            _timetableRepository = timetableRepository;
        }

        public Result<bool> AddTimeTable(Doctor doctor, DateTime startWork, DateTime endWork)
        {
            // TODO:
            // 1. Обратиться к репозиторию, добавить расписание
            // 2. Вернуть result
            var result = new Result<bool>();
            try
            {
                _timetableRepository.InsertTimetable(doctor, startWork, endWork);
                result.StatusCode = StatusCode.OK;
                result.Value = true;
                return result;
            }
            catch(Exception e)
            {
                return new Result<bool>()
                {
                    Description = $"[AddTimeTable] : {e.Message}"
                };
            }
        }

        public Result<bool> EditTimeTable(Doctor doctor, DateTime startWork, DateTime endWork)
        {
            // TODO:
            // 1. Обратиться к репозиторию, изменить расписание
            // 2. Вернуть result
            var result = new Result<bool>();
            try
            {
                _timetableRepository.UpdateTimetable(doctor, startWork, endWork);
                result.StatusCode = StatusCode.OK;
                result.Value = true;
                return result;
            }
            catch (Exception e)
            {
                return new Result<bool>()
                {
                    Description = $"[EditTimeTable] : {e.Message}"
                };
            }
        }

        public Result<List<TimeOnly>> GetTimeTable(Doctor doctor, DateOnly date)
        {
            // TODO:
            // 1. Обратиться к репозиторию, взять расписание доктора
            // 2. Вернуть result
            var result = new Result<List<TimeOnly>>();
            try
            {
                result.StatusCode = StatusCode.OK;
                result.Value = _timetableRepository.SelectTimetableOnDate(doctor, date); ;
                return result;
            }
            catch (Exception e)
            {
                return new Result<List<TimeOnly>>()
                {
                    Description = $"[GetTimeTable] : {e.Message}"
                };
            }
        }
    }
}
