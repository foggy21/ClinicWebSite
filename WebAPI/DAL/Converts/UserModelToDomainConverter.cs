using Domain.DAL;
using Domain.Entities;

namespace DAL.Converts
{
    public static class UserModelToDomainConverter
    {
        public static User? ToDomain(this UserModel model)
        {
            return new User(model?.Name, model?.Phone, model.Role)
            {
                Name = model.Name,
                Phone = model.Phone,
                Role = model.Role,
            };
       }
    }
}
