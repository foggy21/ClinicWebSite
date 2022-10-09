using Domain.Entities;
using Service.Implementations;

namespace Service.Tests
{
    public class UserServiceTest
    {
        private readonly UserService _userService;

        public UserServiceTest(UserService userService)
        {
            _userService = userService;
        }   

        [Fact]
        public void CheckUserWithIncorrectLogin_Fail()
        {
            string loginTest = "NoobMaster69";
            string passwordTest = "12345678";

            var result = _userService.CheckUser(loginTest, passwordTest);

            Assert.False(result.Value);
        }

        [Fact]
        public void CheckUserWithIncorrectPassword_Fail()
        {
            string loginTest = "MisterDoctor";
            string passwordTest = "SuperDoctor";

            var result = _userService.CheckUser(loginTest, passwordTest);

            Assert.False(result.Value);
        }

        [Fact]
        public void CheckUserEmptyLogin_Fail()
        {
            string loginTest = string.Empty;
            string passwordTest = "12345678";

            var result = _userService.CheckUser(loginTest, passwordTest);

            Assert.False(result.Value);

        }

        [Fact]
        public void CheckUserEmptyPassword_Fail()
        {
            string loginTest = "MisterDoctor";
            string passwordTest = "";

            var result = _userService.CheckUser(loginTest, passwordTest);

            Assert.False(result.Value);

        }

        [Fact]
        public void CheckUserTest_Verify()
        {
            string loginTest = "MisterDoctor";
            string passwordTest = "Super%%Doctor$$";

            var result = _userService.CheckUser(loginTest, passwordTest);

            Assert.True(result.Value);
        }

        [Fact]
        public void CreateUserShortPassword_Fail()
        {
            string loginTest = "MisterDoctor";
            string passwordTest = "1234";
            string phoneTest = "88005553535";
            Role roleTest = Role.Patient;

            var result = _userService.CreateUser(loginTest, passwordTest, phoneTest, roleTest);

            Assert.Null(result.Value);
        }

        [Fact]
        public void CreateUserWithExistsLogin_Fail()
        {
            string loginTest = "MisterDoctor";
            string passwordTest = "Super%%Doctor$$";
            string phoneTest = "89123332211";
            Role roleTest = Role.Admin;

            var result = _userService.CreateUser(loginTest,passwordTest, phoneTest, roleTest);

            Assert.Null(result.Value);
        }

        [Fact]
        public void CreateUserEmptyLogin_Fail()
        {
            string loginTest = string.Empty;
            string passwordTest = "Super%%Doctor$$";
            string phoneTest = "89123332211";
            Role roleTest = Role.Admin;

            var result = _userService.CreateUser(loginTest, passwordTest, phoneTest, roleTest);

            Assert.Null(result.Value);
        }

        [Fact]
        public void CreateUserTest_Verify()
        {
            string loginTest = "testLogin";
            string passwordTest = "testPassWithSym$";
            string phoneTest = "89140001122";
            Role roleTest = Role.Patient;
            StatusCode statusCodeTest = StatusCode.OK;


            var result = _userService.CreateUser(loginTest, passwordTest, phoneTest, roleTest);

            Assert.Equal(statusCodeTest, result.StatusCode);
            Assert.Equal(loginTest, result.Value.Name);
            Assert.Equal(roleTest, result.Value.Role);
        }

        [Fact]
        public void GetUserByLoginEmptyLogin_Fail()
        {
            string loginTest = string.Empty;

            var result = _userService.GetUserByLogin(loginTest);

            Assert.Null(result.Value);
        }

        [Fact]
        public void GetUserByLoginNotFound_Fail()
        {
            string loginTest = "NoobMaster69";

            var result = _userService.GetUserByLogin(loginTest);

            Assert.Null(result.Value);
        }

        [Fact]
        public void GetUserByLoginTest_Verify()
        {
            string loginTest = "MisterDoctor";
            StatusCode statusCodeTest = StatusCode.OK;

            var result = _userService.GetUserByLogin(loginTest);

            Assert.Equal(statusCodeTest, result.StatusCode);
            Assert.Equal(loginTest, result.Value.Name);
        }
    }
}