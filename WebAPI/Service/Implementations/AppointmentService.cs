using DAL.Repositories;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.Response;
using Service.Interfaces;

namespace Service.Implementations
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Result<List<DateTime>> GetFreeDatesForSpecialization(Specialization specialization)
        {
            // TODO:
            // 1. Проверить имя специализации на пустоту.
            // 2. Проверить имя специализации на содержание цифр.
            // 3. Получить список дат из репозитория.
            // 4. Передать список в result.
            // 5. Вернуть result.
            var result = new Result<List<DateTime>>();
            try
            {
                if (specialization == null || specialization.NameOfSpecialization == string.Empty)
                {
                    result.Description = "Name of specialization is empty";
                    result.StatusCode = StatusCode.BadRequest;
                    return result;
                }

                var listOfDates = _appointmentRepository.SelectDatesForSpecialization(specialization);

                if (specialization.Id is null)
                {
                    result.Description = "Name of specialization is not exists";
                    result.StatusCode = StatusCode.BadRequest;
                    return result;
                }
                

                if (listOfDates.Any())
                {
                    result.Description = "No free dates";
                    result.StatusCode = StatusCode.NotFound;
                    return result;
                }

                result.StatusCode = StatusCode.OK;
                result.Value = listOfDates;
                return result;
            }
            catch(Exception e)
            {
                return new Result<List<DateTime>>()
                {
                    Description = $"[GetFreeDatesForSpecialization] : {e.Message}"
                };
            }

        }

        public Result<bool> SaveAppointment(Doctor doctor, DateTime date)
        {
            // TODO:
            // 1. Взять список свободных дат из репозитория.
            // 2. Проверить наличие даты в списке.
            // 3. Записать дату в репозиторий с врачом.
            var result = new Result<bool>();
            try
            {
                var listOfFreeDates = GetFreeDatesForSpecialization(doctor.Specialization);

                if (listOfFreeDates.Value == null || !listOfFreeDates.Value.Any())
                {
                    result.Description = "List of date is empty";
                    result.StatusCode = StatusCode.BadRequest;
                    result.Value = false;
                    return result;
                }

                if (!listOfFreeDates.Value.Contains(date))
                {
                    result.Description = "List of date doesn't contain this date";
                    result.StatusCode = StatusCode.NotFound;
                    result.Value = false;
                    return result;
                }

                if (listOfFreeDates.Value[0] <= date && date <= listOfFreeDates.Value[-1])
                {
                    _appointmentRepository.CreateAppointment(doctor, date);
                    result.StatusCode = StatusCode.OK;
                    result.Value = true;
                    return result;
                }
                else
                {
                    result.Description = "Date is out of range of free dates";
                    result.StatusCode = StatusCode.BadRequest;
                    result.Value = false;
                    return result;
                }
                
            }
            catch (Exception e)
            {
                return new Result<bool>()
                {
                    Description = $"[SaveAppointment] : {e.Message}"
                };
            }
        }

        public Result<bool> SaveAppointmentToAnyDoctor(Specialization specialization, DateTime date)
        {
            // TODO:
            // 1. Взять список свободных дат из репозитория.
            // 2. Проверить наличие даты в списке.
            // 3. Записать дату в репозиторий.
            var result = new Result<bool>();
            try
            {
                var listOfFreeDates = GetFreeDatesForSpecialization(specialization);

                if (listOfFreeDates.Value == null || !listOfFreeDates.Value.Any())
                {
                    result.Description = "List of date is empty";
                    result.StatusCode = StatusCode.BadRequest;
                    result.Value = false;
                    return result;
                }

                if (!listOfFreeDates.Value.Contains(date))
                {
                    result.Description = "List of date doesn't contain this date";
                    result.StatusCode = StatusCode.NotFound;
                    result.Value = false;
                    return result;
                }
                _appointmentRepository.CreateAppointmentToAnyDoctor(specialization, date);
                result.StatusCode = StatusCode.OK;
                result.Value = true;
                return result;
            }
            catch (Exception e)
            {
                return new Result<bool>()
                {
                    Description = $"[SaveAppointment] : {e.Message}"
                };
            }
        }
    }
}