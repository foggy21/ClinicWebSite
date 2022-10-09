using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.Response;
using Service.Interfaces;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result<bool> CheckUser(string login, string password)
        {
            //TODO:
            // 1. Найти в репозитории пользователя
            // 2. Вернуть положительный ответ или ошибку, если логин и пароль не совпали
            var result = new Result<bool>();
            try
            {
                var isCorrectUser = _userRepository.GetByLoginAndPassword(login, password);
                if (isCorrectUser == false)
                {
                    result.Description = "Login or password aren't correct.";
                    result.StatusCode = StatusCode.BadRequest;
                    return result;
                }
                result.Value = isCorrectUser;
                result.StatusCode = StatusCode.OK;
                return result;
            } 
            catch (Exception e)
            {
                return new Result<bool>()
                {
                    Description = $"[CheckUser] : {e.Message}"
                };
            }
        }

        public Result<User> CreateUser(string login, string password, string phone, Role role)
        {
            //TODO:
            // 1. Проверить на корректность логин и пароль.
            // 2. Создать объект User
            // 3. Записать в объект поля свежеиспечённого User'a.
            // 4. Вернуть объект User.
            var result = new Result<User>();
            try
            {
                if (password.Length < 8)
                {
                    result.Description = "Password isn't correct.";
                    result.StatusCode = StatusCode.BadRequest;
                    return result;
                }
                result = GetUserByLogin(login);
                if (result.Value != null)
                {
                    result.Description = "Username is already taken.";
                    result.StatusCode = StatusCode.BadRequest;
                    result.Value = null;
                    return result;
                }
                _userRepository.CreateUser(login, password, phone, role);
                result.StatusCode = StatusCode.OK;
                return result;
            } 
            catch(Exception e)
            {
                return new Result<User>()
                {
                    Description = $"[CreateUser] : {e.Message}"
                };
            }
        }

        public Result<User> GetUserByLogin(string login)
        {
            //TODO:
            // 1. Обратиться к репозиторию, если есть такой логин в репе - берем данные, иначе - вернётся ошибка.
            // 2. Создаем объект User, записываем в поля объекта данные, полученные из репозитория.
            // 3. Возвращаем объект User.
            var result = new Result<User>();
            try
            {
                var user = _userRepository.GetByLogin(login);
                if (user == null)
                {
                    result.Description = "User not found.";
                    result.StatusCode = StatusCode.NotFound;
                    return result;
                }
                result.Value = user;
                result.StatusCode = StatusCode.OK;
                return result;
            }
            catch(Exception e)
            {
                return new Result<User>() 
                {
                    Description = $"[GetUserByLogin] : {e.Message}"
                };
            }
        }
    }
}
