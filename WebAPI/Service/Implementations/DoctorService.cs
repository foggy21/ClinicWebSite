using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.Response;
using Service.Interfaces;

namespace Service.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Result<Doctor> CreateDoctor(string? name, Specialization specialization)
        {
            // TODO:
            // 1. Проверять name на пустоту.
            // 2. Проверять name на содержание цифр.
            // 3. Создать доктора в репозитории, записать в result.
            // 4. Вернуть result.
            var result = new Result<Doctor>();
            try
            {
                if (name == string.Empty || name == null)
                {
                    result.Description = "Doctor's name is empty";
                    result.StatusCode = StatusCode.BadRequest;
                    return result;
                }

                foreach (char item in name)
                {
                    if (char.IsDigit(item))
                    {
                        result.Description = "Doctor's name contains digit";
                        result.StatusCode = StatusCode.BadRequest;
                        return result;
                    }
                }

                result.Value = _doctorRepository.CreateDoctor(name, specialization);
                result.StatusCode = StatusCode.OK;
                return result;
            } 
            catch(Exception e)
            {
                return new Result<Doctor>()
                {
                    Description = $"[CreateDoctor] : {e.Message}"
                };
            }
        }

        public Result<bool> DeleteDoctor(Doctor doctor)
        {
            // TODO:
            // 1. Найти доктора по id.
            // 2. Если значение не равно null, то удалить, вернуть true.
            // 3. Иначе вернуть false.
            var result = new Result<bool>();
            try
            {
                var isCorrectDoctor = GetDoctorById(doctor.Id);
                if (isCorrectDoctor.Value == null)
                {
                    result.Description = "Doctor is not exist";
                    result.StatusCode = StatusCode.NotFound;
                    result.Value = false;
                    return result;
                }
                _doctorRepository.Delete(doctor);
                result.StatusCode = StatusCode.OK;
                result.Value = true;
                return result;
            } 
            catch (Exception e)
            {
                return new Result<bool>()
                {
                    Description = $"[DeleteDoctor] : {e.Message}"
                };
            }
        }

        public Result<Doctor> GetDoctorById(int? id)
        {
            // TODO:
            // 1. Проверить наличие такого доктора по id в репозитории.
            // 2. Записать доктора в result.
            // 3. Вернуть result.
            var result = new Result<Doctor>();
            try
            {
                var isCorrectDoctor = _doctorRepository.FindDoctorById(id);
                if (isCorrectDoctor == null)
                {
                    result.Description = "Doctor is not exist";
                    result.StatusCode = StatusCode.NotFound;
                    result.Value = null;
                    return result;
                }
                result.StatusCode = StatusCode.OK;
                result.Value = isCorrectDoctor;
                return result;
            }
            catch(Exception e)
            {
                return new Result<Doctor>()
                {
                    Description = $"[GetDoctorById] : {e.Message}"
                };
            }
        }

        public Result<Doctor> GetDoctorBySpecialization(Specialization specialization)
        {
            // TODO:
            // 1. Проверить наличие такого доктора по specialization в репозитории.
            // 2. Записать доктора в result.
            // 3. Вернуть result.
            var result = new Result<Doctor>();
            try
            {
                var isCorrectDoctor = _doctorRepository.FindDoctorBySpecialization(specialization);
                if (isCorrectDoctor == null)
                {
                    result.Description = "Doctor is not exist";
                    result.StatusCode = StatusCode.NotFound;
                    result.Value = null;
                    return result;
                }
                result.StatusCode = StatusCode.OK;
                result.Value = isCorrectDoctor;
                return result;
            }
            catch (Exception e)
            {
                return new Result<Doctor>()
                {
                    Description = $"[GetDoctorBySpecialization] : {e.Message}"
                };
            }
        }

        public Result<List<Doctor>> GetDoctors()
        {
            // TODO:
            // 1. Обратиться в репозиторий, вернуть список докторов.
            // 2. Записать этот список в result.
            // 3. Вывести result.
            var result = new Result<List<Doctor>>();
            try
            {
                var listOfDoctors = _doctorRepository.Select().ToList();
                if (!listOfDoctors.Any())
                {
                    result.Description = "No doctors";
                    result.StatusCode = StatusCode.NotFound;
                    result.Value = null;
                }
                result.StatusCode = StatusCode.OK;
                result.Value = listOfDoctors;
                return result;
            }
            catch(Exception e)
            {
                return new Result<List<Doctor>>()
                {
                    Description = $"[GetDoctors] : {e.Message}"
                };
            }
        }
    }
}
