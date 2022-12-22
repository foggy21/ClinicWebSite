using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Implementations;
using WebAPI.Views;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService service)
        {
            _userService = service;
        }

        [HttpGet("GetUserByLogin")]
        public ActionResult<UserView> GetUserByLogin(string login)
        {
            if (string.IsNullOrEmpty(login)) return Problem(statusCode: 404, detail: "Login is empty or null.");

            var userResult = _userService.GetUserByLogin(login);
            if (userResult.StatusCode != Domain.Entities.StatusCode.OK) return Problem(statusCode: (int)userResult.StatusCode, detail: "User isn't found.");

            return Ok(new UserView
            {
                Id = userResult.Value.Id,
                Name = userResult.Value.Name,
                Password = userResult.Value.Password,
                Phone = userResult.Value.Phone,
                Role = userResult.Value.Role
            });
        }

        [HttpPost("CreateUser")]
        public ActionResult<UserView> CreateUser(UserView userView)
        {
            if (string.IsNullOrEmpty(userView.Name)) return Problem(statusCode: 404, detail: "Login is empty or null.");
            if (string.IsNullOrEmpty(userView.Password)) return Problem(statusCode: 404, detail: "Password is empty or null.");

            var userResult = _userService.CreateUser(userView.Name, userView.Password, userView.Phone, userView.Role);

            if (userResult.StatusCode != Domain.Entities.StatusCode.OK) return Problem(statusCode: (int)userResult.StatusCode, detail: "User isn't found.");

            return Ok(userView);
        }

        [HttpGet("CheckUser")]
        public ActionResult CheckUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login)) return Problem(statusCode: 404, detail: "Login is empty or null.");
            if (string.IsNullOrEmpty(password)) return Problem(statusCode: 404, detail: "Password is empty or null.");

            var userResult = _userService.CheckUser(login, password);
            if (userResult.StatusCode != Domain.Entities.StatusCode.OK) return Problem(statusCode: (int)userResult.StatusCode, detail: "User isn't found.");

            return Ok();
        }
    }
}
