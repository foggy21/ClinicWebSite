using Domain.Entities;
using Domain.RepositoryInterfaces;
using Moq;
using Service.Implementations;

namespace Service.Tests
{
    public class UserServiceTest
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserServiceTest(UserService userService)
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }   

        [Fact]
        public void CheckUserWithIncorrectData_Fail()
        {
            string loginTest = "NoobMaster69";
            string passwordTest = "erretewrt";
            _userRepositoryMock.Setup(repository => repository.GetByLoginAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(() => false);

            var result = _userService.CheckUser(loginTest, passwordTest);

            Assert.False(result.Value);
        }

        [Fact]
        public void CheckUserWithEmptyPassword_Fail()
        {
            string loginTest = "MisterDoctor";
            string passwordTest = string.Empty;

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
        public void CheckUserTest_Verify()
        {
            string loginTest = "MisterDoctor";
            string passwordTest = "Super%%Doctor$$";

            _userRepositoryMock.Setup(repository => repository.GetByLoginAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(() => true);

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

            _userRepositoryMock.Setup(repository => repository.CreateUser(It.IsAny<User>())).Returns(() => null);


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

            _userRepositoryMock.Setup(repository => repository.CreateUser(It.IsAny<User>()))
                .Returns(() => new User(loginTest, phoneTest, roleTest));

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

            _userRepositoryMock.Setup(repository => repository.GetByLogin(It.IsAny<string>())).Returns(() => null);

            var result = _userService.GetUserByLogin(loginTest);

            Assert.Null(result.Value);
        }

        [Fact]
        public void GetUserByLoginTest_Verify()
        {
            string loginTest = "MisterDoctor";
            string phoneTest = "89123332211";
            Role roleTest = Role.Admin;
            StatusCode statusCodeTest = StatusCode.OK;

            _userRepositoryMock.Setup(repository => repository.GetByLogin(It.IsAny<string>()))
                .Returns(() => new User(loginTest, phoneTest, roleTest));

            var result = _userService.GetUserByLogin(loginTest);

            Assert.Equal(statusCodeTest, result.StatusCode);
            Assert.Equal(loginTest, result.Value.Name);
        }
    }
}