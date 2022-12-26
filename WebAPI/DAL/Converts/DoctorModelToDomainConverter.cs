using Domain.DAL;
using Domain.Entities;

namespace DAL.Converts
{
    public static class DoctorModelToDomainConverter
    {
        public static Doctor? ToDomain(this DoctorModel doctor)
        {
            return new Doctor(doctor.Name, doctor.specialization?.ToDomain())
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialization = doctor.specialization?.ToDomain()
            };
        }
    }
}
