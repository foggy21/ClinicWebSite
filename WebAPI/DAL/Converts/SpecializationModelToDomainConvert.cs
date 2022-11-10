using Domain.DAL;
using Domain.Entities;

namespace DAL.Converts
{
    public static class SpecializationModelToDomainConvert
    {
        public static Specialization? ToDomain(this SpecializationModel specializationModel)
        {
            return new Specialization(specializationModel.NameOfSpecialization)
            {
                Id = specializationModel.Id,
                NameOfSpecialization = specializationModel.NameOfSpecialization
            };
        }
    }
}
